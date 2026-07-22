using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Address
{
    public long AddressIdPk { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public long? CityIdFk { get; set; }

    public string? Pincode { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual City? CityIdFkNavigation { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<Dc> Dcs { get; set; } = new List<Dc>();

    public virtual ICollection<StoreProfile> StoreProfiles { get; set; } = new List<StoreProfile>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
