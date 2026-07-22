using ManufacturingLogisticsMVC.Models;
using ManufacturingLogisticsMVC.Controllers.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ManufacturingLogisticsMVC.Repository.StoreProfiles
{
    public class StoreProfilesRepository : IStoreProfilesRepository
    {
        private readonly ManufacturingLogisticsDbContext _context;

        public StoreProfilesRepository(ManufacturingLogisticsDbContext context)
        {
            _context = context;
        }

        public bool InsertStore(StoreProfile store)
        {
            long nextId = _context.StoreProfiles.Any()
        ? _context.StoreProfiles.Max(s => s.StoreIdPk) + 1
        : 1;

            store.StoreIdPk = nextId;
            store.CreatedDateTime = DateTime.Now;
            store.UpdatedDateTime = DateTime.Now;
            _context.StoreProfiles.Add(store);
            return _context.SaveChanges() > 0;
        }

        public StoreProfile? FindStoreById(long storeId)
        {
            StoreProfile? store = _context.StoreProfiles.Find(storeId);
            if (store == null)
            {
                throw new StoreNotFoundException("Store Not Found");
            }
            return store;
        }

        public IEnumerable<StoreProfile> FilterStores(string storeName)
        {
            if (string.IsNullOrWhiteSpace(storeName))
            {
                throw new NoStoresFoundException("Please enter a store name to filter");
            }

            var stores = _context.StoreProfiles
                .Where(store => store.StoreName.Contains(storeName))
                .ToList();

            if (!stores.Any())
            {
                throw new NoStoresFoundException("No Store Found with this name");
            }

            return stores;
        }

        public bool UpdateStore(long id, StoreProfile store)
        {
            StoreProfile? existingStore = _context.StoreProfiles.Find(id);
            if (existingStore == null)
            {
                throw new StoreNotFoundException("Store Not Found");
            }
            bool managerExists = _context.Managers.Any(m => m.ManagersIdPk == store.ManagersIdFk);
            if (!managerExists)
            {
                throw new ManagerNotFoundException("Store Manager Id does not exist");
            }

            existingStore.StoreName = store.StoreName;
            existingStore.ManagersIdFk = store.ManagersIdFk;
            existingStore.AddressIdFk = store.AddressIdFk;
            existingStore.StoreStatusIdFk = store.StoreStatusIdFk;
            existingStore.UpdatedByUserIdFk = store.UpdatedByUserIdFk;

            int rowsAffected = _context.SaveChanges();
            if (rowsAffected == 0)
            {
                throw new NoChangesFoundException("NO changes found");
            }

            return true;
        }

        public IEnumerable<object> FindAllStores()
        {
            // Materialize first (.ToList()) since StoreCode is a computed C# property
            // and can't be translated into SQL by EF Core.
            var joined =
                (from store in _context.StoreProfiles
                 join manager in _context.Managers
                 on store.ManagersIdFk equals manager.ManagersIdPk
                 select new { store, manager })
                .ToList();

            var result = joined.Select(x => new
            {
                x.store.StoreIdPk,
                x.store.StoreCode,      // computed: STR001, STR002, ...
                x.store.StoreName,
                x.store.AddressIdFk,
                x.store.StoreStatusIdFk,
                x.manager.ManagersName,
                x.manager.ManagersContactPhone,
                x.manager.ManagersEmail
            });

            return result;
        }

        public IEnumerable<object> GetAllManagers()
        {
            var managers = _context.Managers
                .Select(m => new
                {
                    id = m.ManagersIdPk,
                    name = m.ManagersName
                })
                .ToList();

            return managers;
        }
        public IEnumerable<object> GetAllAddresses()
        {
            // Materialize first since we're building a display label in C#
            var addresses = _context.Addresses
                .Include(a => a.CityIdFkNavigation)
                .ToList();

            return addresses.Select(a => new
            {
                id = a.AddressIdPk,
                label = $"{a.AddressLine1}" +
                        (string.IsNullOrWhiteSpace(a.AddressLine2) ? "" : $", {a.AddressLine2}") +
                        (a.CityIdFkNavigation != null ? $", {a.CityIdFkNavigation.CityName}" : "") +
                        (string.IsNullOrWhiteSpace(a.Pincode) ? "" : $" - {a.Pincode}")
            });
        }

        public IEnumerable<object> GetAllUsers()
        {
            var users = _context.Users
                .Select(u => new
                {
                    id = u.UserIdPk,
                    name = u.UserName
                })
                .ToList();

            return users;
        }
    }
}