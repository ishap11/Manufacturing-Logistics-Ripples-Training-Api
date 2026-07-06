using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class Delivery
    {
        public long DeliveryIdPk { get; set; }
        public long DispatchIdFk { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public long ReceivedByManagersIdFk { get; set; }
        public long DeliveryStatusIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual Dispatch? Dispatch { get; set; }
        public virtual Managers? ReceivedByManager { get; set; }
        public virtual Catalog? DeliveryStatus { get; set; }
    }
}
