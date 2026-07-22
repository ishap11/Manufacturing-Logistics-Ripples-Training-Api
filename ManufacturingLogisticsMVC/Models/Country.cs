using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Country
{
    public long CountryIdPk { get; set; }

    public string? CountryName { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<State> States { get; set; } = new List<State>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
