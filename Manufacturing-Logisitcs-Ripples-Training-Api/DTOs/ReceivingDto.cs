using System.Collections.Generic;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.DTOs
{
    public class ReceivingDto
    {
        public string ReceivingId { get; set; } = null!;
        public string Shipment { get; set; } = null!;
        public string Warehouse { get; set; } = null!;
        public int TotalProducts { get; set; }
        public int TotalQuantity { get; set; }
        public string Status { get; set; } = null!;
        public string CreatedDate { get; set; } = null!;
        public List<ReceivingItemDto> Items { get; set; } = new List<ReceivingItemDto>();
    }
}
