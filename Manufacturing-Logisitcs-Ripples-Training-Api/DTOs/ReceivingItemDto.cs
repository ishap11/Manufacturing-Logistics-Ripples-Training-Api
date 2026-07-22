namespace Manufacturing_Logisitcs_Ripples_Training_Api.DTOs
{
    public class ReceivingItemDto
    {
        public string ProductId { get; set; } = null!;
        public string? ProductName { get; set; }
        public int OrderedQty { get; set; }
        public int ReceivedQty { get; set; }
        public int DamagedQty { get; set; }
        public string QcStatus { get; set; } = null!;
    }
}
