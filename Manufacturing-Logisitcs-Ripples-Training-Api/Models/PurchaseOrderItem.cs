using System;
using System.Collections.Generic;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models;

public partial class PurchaseOrderItem
{
    public long PoItemIdPk { get; set; }

    public long? PurchaseOrderIdFk { get; set; }

    public short? PurchaseQuantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public long? ProductSupplierIdFk { get; set; }

    public virtual PurchaseOrder? PurchaseOrder { get; set; }
}
