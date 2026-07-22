using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class StoreOrderItems
    {
        public long StoreOrderItemsIdPk { get; set; }
        public long? StoreOrdersIdFk { get; set; }
        public long? ProductIdFk { get; set; }
        public int? RequestedQuantity { get; set; }
        public int? AllocatedQuantity { get; set; }
        public string? AllocationNotes { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual StoreOrders? StoreOrder { get; set; }
        public virtual Product? Product { get; set; }
    }
}
