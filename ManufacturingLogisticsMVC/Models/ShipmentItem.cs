using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class ShipmentItem
{
    public long ShipmentItemIdPk { get; set; }

    public long ShipmentIdFk { get; set; }

    public long PoItemIdFk { get; set; }

    public long ShippedQuantity { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual PurchaseOrderItem PoItemIdFkNavigation { get; set; } = null!;

    public virtual Shipment ShipmentIdFkNavigation { get; set; } = null!;

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
