using System;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class ShipmentItem
    {
        public long ShipmentItemIdPk { get; set; }
        public long ShipmentIdFk { get; set; }
        public long POItemIdFk { get; set; }
        public long ShippedQuantity { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public long? CreatedByUserIdFk { get; set; }
        public long? UpdatedByUserIdFk { get; set; }

        public virtual Shipment? Shipment { get; set; }
        public virtual PurchaseOrderItem? POItem { get; set; }
    }
}
