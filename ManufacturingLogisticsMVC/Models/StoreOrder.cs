using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class StoreOrder
{
    public long StoreOrdersIdPk { get; set; }

    public long? StoreIdFk { get; set; }

    public long? OrderStatusIdFk { get; set; }

    public DateOnly? RequestedDeliveryDate { get; set; }

    public DateOnly? ExpectedDeliveryDate { get; set; }

    public long? OrderPriorityIdFk { get; set; }

    public decimal? TotalOrderValue { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual OrderPriority? OrderPriorityIdFkNavigation { get; set; }

    public virtual Catalog? OrderStatusIdFkNavigation { get; set; }

    public virtual StoreProfile? StoreIdFkNavigation { get; set; }

    public virtual ICollection<StoreOrderItem> StoreOrderItems { get; set; } = new List<StoreOrderItem>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
