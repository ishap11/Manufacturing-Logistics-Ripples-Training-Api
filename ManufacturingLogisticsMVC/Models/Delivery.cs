using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Delivery
{
    public long DeliveryIdPk { get; set; }

    public long DispatchIdFk { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public long ReceivedByManagersIdFk { get; set; }

    public long DeliveryStatusIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Catalog DeliveryStatusIdFkNavigation { get; set; } = null!;

    public virtual Dispatch DispatchIdFkNavigation { get; set; } = null!;

    public virtual Manager ReceivedByManagersIdFkNavigation { get; set; } = null!;

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
