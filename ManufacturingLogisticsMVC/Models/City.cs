using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class City
{
    public long CityIdPk { get; set; }

    public string? CityName { get; set; }

    public long? StateIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual State? StateIdFkNavigation { get; set; }

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
