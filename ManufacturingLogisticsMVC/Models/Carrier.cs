using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Carrier
{
    public long CarrierIdPk { get; set; }

    public string CarrierName { get; set; } = null!;

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
