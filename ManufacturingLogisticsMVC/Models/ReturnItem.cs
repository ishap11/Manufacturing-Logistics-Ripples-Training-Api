using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class ReturnItem
{
    public long ReturnItemIdPk { get; set; }

    public long ReturnIdFk { get; set; }

    public long ProductIdFk { get; set; }

    public int ReturnedQuantity { get; set; }

    public string? ReturnReason { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Product ProductIdFkNavigation { get; set; } = null!;

    public virtual Return ReturnIdFkNavigation { get; set; } = null!;

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
