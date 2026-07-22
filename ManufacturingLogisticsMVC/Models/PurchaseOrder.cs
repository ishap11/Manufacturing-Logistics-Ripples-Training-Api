using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class PurchaseOrder
{
    public long PurchaseOrderIdPk { get; set; }

    public long? SupplierIdFk { get; set; }

    public long? OrderStatusIdFk { get; set; }

    public long? CurrencyIdFk { get; set; }

    public DateOnly PoDate { get; set; }

    public DateOnly ExpectedDeliveryDate { get; set; }

    public long? ApprovedByUserIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? ApprovedByUserIdFkNavigation { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Catalog? CurrencyIdFkNavigation { get; set; }

    public virtual Catalog? OrderStatusIdFkNavigation { get; set; }

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual Supplier? SupplierIdFkNavigation { get; set; }

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
