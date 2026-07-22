using System.Collections.Generic;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.DTOs
{
    public class ShipmentDto
    {
        public long Id { get; set; }
        public string ShipmentId { get; set; } = null!;
        public List<ShipmentProductDto> Products { get; set; } = new List<ShipmentProductDto>();
    }
}
