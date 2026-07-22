using ManufacturingLogisticsMVC.Bo.StoreProfiles;
using ManufacturingLogisticsMVC.Models;

namespace ManufacturingLogisticsMVC.Facade.StoreProfiles
{
    public class StoreProfilesFacade
    {
        private readonly StoreProfilesBO _storeBO;

        public StoreProfilesFacade(StoreProfilesBO storeBO) 
        { 
            _storeBO = storeBO;
        }

        public bool InsertStore(StoreProfile store)
        {
            return _storeBO.InsertStore(store);
        }

        public StoreProfile? FindStoreById(long storeId)
        {
            return _storeBO.FindStoreById(storeId);
        }

        
        public IEnumerable<StoreProfile> FilterStores(string storeName)
        {
            return _storeBO.FilterStores(storeName);
        }

        public bool UpdateStore(long id,StoreProfile store)
        {
            return _storeBO.UpdateStore(id,store);
        }

       
        public IEnumerable<object> FindAllStores()
        {
            return _storeBO.FindAllStores();
        }

        public IEnumerable<object> GetAllManagers()
        {
            return _storeBO.GetAllManagers();
        }
        public IEnumerable<object> GetAllAddresses()
        {
            return _storeBO.GetAllAddresses();
        }

        public IEnumerable<object> GetAllUsers()
        {
            return _storeBO.GetAllUsers();
        }
    }
}