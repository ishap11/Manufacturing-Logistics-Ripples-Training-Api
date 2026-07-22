using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class State
{
    public long StateIdPk { get; set; }

    public string? StateName { get; set; }

    public long? CountryIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country? CountryIdFkNavigation { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
