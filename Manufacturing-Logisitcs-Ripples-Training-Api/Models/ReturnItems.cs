using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class ReturnItems
    {
        public long ReturnItemIdPk { get; set; }
        public long ReturnIdFk { get; set; }
        public long ProductIdFk { get; set; }
        public int ReturnedQuantity { get; set; }
        public string? ReturnReason { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual Return? Return { get; set; }
        public virtual Product? Product { get; set; }
    }
}
