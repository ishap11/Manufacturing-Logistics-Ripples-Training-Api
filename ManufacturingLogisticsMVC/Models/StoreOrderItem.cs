using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class StoreOrderItem
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

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Product? ProductIdFkNavigation { get; set; }

    public virtual StoreOrder? StoreOrdersIdFkNavigation { get; set; }

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
