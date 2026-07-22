using ManufacturingLogisticsMVC.Models;
using ManufacturingLogisticsMVC.Repository.StoreProfiles;
using System.Text.RegularExpressions;

namespace ManufacturingLogisticsMVC.Bo.StoreProfiles
{
    public class StoreProfilesBO
    {
        private readonly IStoreProfilesRepository _repository;

        public string? StoreName { get; set; }
        public StoreProfilesBO() { }
        
        public StoreProfilesBO(IStoreProfilesRepository repository)
        {
            _repository = repository;
        }

        public bool InsertStore(StoreProfile store)
        {
            ValidateStore(store);
            return _repository.InsertStore(store);
        }

        public StoreProfile? FindStoreById(long storeId)
        {
            ValidateStoreId(storeId);
            return _repository.FindStoreById(storeId);
        }

        

        public IEnumerable<StoreProfile> FilterStores(string storeName)
        {
            ValidateFilter(storeName);
            return _repository.FilterStores(storeName);
        }
        public bool UpdateStore(long id, StoreProfile store)
        {
            ValidateStore(store);
            return _repository.UpdateStore(id,store);
        }   

        public IEnumerable<object> FindAllStores()
        {
            return _repository.FindAllStores();
        }


        public IEnumerable<object> GetAllManagers()
        {
            return _repository.GetAllManagers();
        }
        public IEnumerable<object> GetAllAddresses()
        {
            return _repository.GetAllAddresses();
        }

        public IEnumerable<object> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public void ValidateStore(StoreProfile store)
        {
            if (store == null)
                throw new Exception("Store object cannot be null");

         

            if (string.IsNullOrWhiteSpace(store.StoreName))
                throw new Exception("Store Name is required");

            if (!Regex.IsMatch(store.StoreName, @"^[a-zA-Z0-9  ]+$"))
                throw new Exception("Store Name can only contain letters and numbers");



            if (!store.ManagersIdFk.HasValue || store.ManagersIdFk.Value <= 0)
                throw new Exception("Invalid Store Manager Id");

            if (store.AddressIdFk <= 0)
                throw new Exception("Invalid Address Id");

            if (store.StoreStatusIdFk <= 0)
                throw new Exception("Invalid Store Status Id");
        }

        public void ValidateStoreId(long storeId)
        {
            if (storeId <= 0)
                throw new Exception("Store Id must be greater than zero");
        }

        public void ValidateFilter(string storeName)
        {
            if (string.IsNullOrWhiteSpace(storeName))
                throw new Exception("Store Name is required for filtering");
        }
    }
}