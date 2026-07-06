using System.Collections.Generic;
using System.Threading.Tasks;
using Manufacturing_Logisitcs_Ripples_Training_Api.Models;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Repositories
{
    public interface IReceivingRepository
    {
        Task<IEnumerable<DC>> GetWarehousesAsync();
        Task<IEnumerable<Shipment>> GetShipmentsAsync();
        Task<IEnumerable<DcReceiving>> GetAllReceivingAsync();
        Task<DcReceiving?> GetReceivingByIdAsync(long id);
        Task<DC?> FindDcByNameOrIdAsync(string warehouseStr);
        Task<Shipment?> FindShipmentByTrackingOrIdAsync(string shipmentStr);
        Task<Catalog?> FindCatalogStatusAsync(string status);
        Task<Product?> FindProductByNameAsync(string name);
        Task<ShipmentItem?> FindShipmentItemForProductAsync(long shipmentId, long productId);
        Task<long> GetNextReceivingIdAsync();
        Task<long> GetNextReceivingItemIdAsync();
        Task<long> GetNextCatalogIdAsync();
        Task<long> GetNextDcIdAsync();
        Task<long> GetNextShipmentIdAsync();
        void AddReceiving(DcReceiving receiving);
        void AddReceivingItem(DcReceivingItem item);
        void RemoveReceivingItems(IEnumerable<DcReceivingItem> items);
        void RemoveReceiving(DcReceiving receiving);
        void AddCatalog(Catalog catalog);
        void AddDc(DC dc);
        void AddShipment(Shipment shipment);
        Task SaveChangesAsync();
    }
}
