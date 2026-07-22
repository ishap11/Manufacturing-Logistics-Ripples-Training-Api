using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class StoreOrders
    {
        public long StoreOrdersIdPk { get; set; }
        public long? StoreIdFk { get; set; }
        public long? OrderStatusIdFk { get; set; }
        public DateTime? RequestedDeliveryDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public long? OrderPriorityIdFk { get; set; }
        public decimal? TotalOrderValue { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual StoreProfiles? Store { get; set; }
        public virtual Catalog? OrderStatus { get; set; }
        public virtual OrderPriority? OrderPriority { get; set; }
    }
}
