using System.Collections.Generic;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.DTOs
{
    public class ReceivingDto
    {
        public string ReceivingId { get; set; } = null!;
        public string Shipment { get; set; } = null!; // Shipment tracking number or code
        public string Warehouse { get; set; } = null!;  // DC Name or code
        public int TotalProducts { get; set; }
        public int TotalQuantity { get; set; }
        public string Status { get; set; } = "Pending"; // "Pending" | "Completed" | "Cancelled"
        public string CreatedDate { get; set; } = null!;
        public List<ReceivingItemDto> Items { get; set; } = new List<ReceivingItemDto>();
    }
}
