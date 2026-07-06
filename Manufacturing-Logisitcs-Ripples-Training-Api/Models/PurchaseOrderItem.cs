using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class PurchaseOrderItem
    {
        public long POItemIdPk { get; set; }
        public long? PurchaseOrderIdFk { get; set; }
        public long? ProductIdFk { get; set; }
        public short? PurchaseQuantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual Product? Product { get; set; }
    }
}
