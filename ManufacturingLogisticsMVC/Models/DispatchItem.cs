using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class DispatchItem
{
    public long DispatchItemIdPk { get; set; }

    public long DispatchIdFk { get; set; }

    public long ProductIdFk { get; set; }

    public int DispatchedQuantity { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Dispatch DispatchIdFkNavigation { get; set; } = null!;

    public virtual Product ProductIdFkNavigation { get; set; } = null!;

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
