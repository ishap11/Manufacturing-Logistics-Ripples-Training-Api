using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class PurchaseOrder
    {
        public long PurchaseOrderIdPk { get; set; }
        public long? SupplierIdFk { get; set; }
        public long? OrderStatusIdFk { get; set; }
        public long? CurrencyIdFk { get; set; }
        public DateTime PoDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public long? ApprovedByUserIdFk { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();
        public virtual Suppliers? Supplier { get; set; }
        public virtual Catalog? OrderStatus { get; set; }
        public virtual Catalog? Currency { get; set; }
        public virtual Users? ApprovedByUser { get; set; }
    }
}
