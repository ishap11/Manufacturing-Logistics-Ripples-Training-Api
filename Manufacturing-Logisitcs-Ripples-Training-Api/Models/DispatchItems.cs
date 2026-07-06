using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class DispatchItems
    {
        public long DispatchItemIdPk { get; set; }
        public long DispatchIdFk { get; set; }
        public long ProductIdFk { get; set; }
        public int DispatchedQuantity { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual Dispatch? Dispatch { get; set; }
        public virtual Product? Product { get; set; }
    }
}
