using System.Collections.Generic;
using System.Threading.Tasks;
using Manufacturing_Logisitcs_Ripples_Training_Api.DTOs;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Services
{
    public interface IReceivingService
    {
        Task<IEnumerable<WarehouseDto>> GetWarehousesAsync();
        Task<IEnumerable<ShipmentDto>> GetShipmentsAsync();
        Task<IEnumerable<ReceivingDto>> SearchReceivingAsync(string? keyword);
        Task<IEnumerable<ReceivingDto>> GetReceivingByStatusAsync(string status);
        Task<ReceivingDto?> GetReceivingByIdAsync(string receivingId);
        Task<ReceivingDto> AddReceivingAsync(ReceivingDto receiving);
        Task<ReceivingDto> UpdateReceivingAsync(ReceivingDto receiving);
        Task<bool> DeleteReceivingAsync(string receivingId);
    }
}
