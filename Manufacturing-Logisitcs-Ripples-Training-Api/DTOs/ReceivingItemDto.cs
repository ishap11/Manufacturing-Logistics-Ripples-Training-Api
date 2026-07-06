namespace Manufacturing_Logisitcs_Ripples_Training_Api.DTOs
{
    public class ReceivingItemDto
    {
        public string ProductName { get; set; } = null!;
        public int OrderedQty { get; set; }
        public int ReceivedQty { get; set; }
        public int DamagedQty { get; set; }
        public string QcStatus { get; set; } = "Pending"; // "Pending" | "Passed" | "Failed"
    }
}
