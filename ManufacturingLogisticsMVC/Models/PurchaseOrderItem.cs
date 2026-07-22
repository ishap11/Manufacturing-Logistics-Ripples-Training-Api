using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class PurchaseOrderItem
{
    public long PoItemIdPk { get; set; }

    public long? PurchaseOrderIdFk { get; set; }

    public long? ProductIdFk { get; set; }

    public short? PurchaseQuantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Product? ProductIdFkNavigation { get; set; }

    public virtual PurchaseOrder? PurchaseOrderIdFkNavigation { get; set; }

    public virtual ICollection<ShipmentItem> ShipmentItems { get; set; } = new List<ShipmentItem>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
