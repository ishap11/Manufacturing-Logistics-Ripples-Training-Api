using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class OrderPriority
    {
        public long OrderPriorityIdPk { get; set; }
        public string PriorityName { get; set; } = null!;
        public string? PriorityDescription { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }
    }
}
