using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Manager
{
    public long ManagersIdPk { get; set; }

    public string ManagersName { get; set; } = null!;

    public string? ManagersContactCode { get; set; }

    public string? ManagersContactPhone { get; set; }

    public string? ManagersEmail { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<StoreProfile> StoreProfiles { get; set; } = new List<StoreProfile>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
