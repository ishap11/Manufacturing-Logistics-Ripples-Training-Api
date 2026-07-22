using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Location
{
    public long LocationIdPk { get; set; }

    public string LocationName { get; set; } = null!;

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<Shipment> ShipmentCurrentLocationIdFkNavigations { get; set; } = new List<Shipment>();

    public virtual ICollection<Shipment> ShipmentOriginLocationIdFkNavigations { get; set; } = new List<Shipment>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
