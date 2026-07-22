using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Dispatch
{
    public long DispatchIdPk { get; set; }

    public long DcIdFk { get; set; }

    public long StoreIdFk { get; set; }

    public DateOnly DispatchDate { get; set; }

    public long DispatchStatusIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Dc DcIdFkNavigation { get; set; } = null!;

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<DispatchItem> DispatchItems { get; set; } = new List<DispatchItem>();

    public virtual Catalog DispatchStatusIdFkNavigation { get; set; } = null!;

    public virtual StoreProfile StoreIdFkNavigation { get; set; } = null!;

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
