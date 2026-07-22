using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class DcReceiving
{
    public long DcReceivingIdPk { get; set; }

    public long DcIdFk { get; set; }

    public long ShipmentIdFk { get; set; }

    public long ReceivingStatusIdFk { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Dc DcIdFkNavigation { get; set; } = null!;

    public virtual ICollection<DcReceivingItem> DcReceivingItems { get; set; } = new List<DcReceivingItem>();

    public virtual Catalog ReceivingStatusIdFkNavigation { get; set; } = null!;

    public virtual Shipment ShipmentIdFkNavigation { get; set; } = null!;

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
