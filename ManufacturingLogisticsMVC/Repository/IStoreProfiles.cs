using ManufacturingLogisticsMVC.Models;

namespace ManufacturingLogisticsMVC.Repository.StoreProfiles
{
    public interface IStoreProfilesRepository
    {
        bool InsertStore(StoreProfile store);
        StoreProfile? FindStoreById(long storeId);
        IEnumerable<StoreProfile> FilterStores(string storeName);
        bool UpdateStore(long id, StoreProfile store);      
        IEnumerable<object> FindAllStores();
        IEnumerable<object> GetAllManagers();
        IEnumerable<object> GetAllAddresses();   
        IEnumerable<object> GetAllUsers();

    }
}