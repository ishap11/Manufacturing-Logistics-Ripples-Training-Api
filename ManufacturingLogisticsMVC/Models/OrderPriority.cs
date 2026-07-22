using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class OrderPriority
{
    public long OrderPriorityIdPk { get; set; }

    public string PriorityName { get; set; } = null!;

    public string? PriorityDescription { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<StoreOrder> StoreOrders { get; set; } = new List<StoreOrder>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
