namespace Manufacturing_Logisitcs_Ripples_Training_Api.DTOs
{
    public class ShipmentProductDto
    {
        public long Id { get; set; }
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public int OrderedQty { get; set; }
    }
}
