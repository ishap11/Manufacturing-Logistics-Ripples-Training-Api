using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class DcReceivingItem
    {
        public long DcReceivingItemsIdPk { get; set; }
        public long DcReceivingIdFk { get; set; }
        public long ProductIdFk { get; set; }
        public int ReceivedQuantity { get; set; }
        public int AcceptedQuantity { get; set; }
        public int? DamagedQuantity { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual DcReceiving? DcReceiving { get; set; }
        public virtual Product? Product { get; set; }
    }
}
