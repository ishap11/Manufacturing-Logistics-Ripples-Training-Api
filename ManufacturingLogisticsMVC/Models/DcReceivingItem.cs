using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class DcReceivingItem
{
    public long DcReceivingItemsIdPk { get; set; }

    public long DcReceivingIdFk { get; set; }

    public long ProductIdFk { get; set; }

    public int ReceivedQuantity { get; set; }

    public int AcceptedQuantity { get; set; }

    public int? DamagedQuantity { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual DcReceiving DcReceivingIdFkNavigation { get; set; } = null!;

    public virtual Product ProductIdFkNavigation { get; set; } = null!;

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
