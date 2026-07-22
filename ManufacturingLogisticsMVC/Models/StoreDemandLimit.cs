using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class StoreDemandLimit
{
    public long LimitIdPk { get; set; }

    public long? StoreIdFk { get; set; }

    public long? ProductIdFk { get; set; }

    public int? MinOrderLevel { get; set; }

    public int? MaxOrderLevel { get; set; }

    public DateOnly? EffectiveFromDate { get; set; }

    public DateOnly? EffectiveToDate { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Product? ProductIdFkNavigation { get; set; }

    public virtual StoreProfile? StoreIdFkNavigation { get; set; }

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
