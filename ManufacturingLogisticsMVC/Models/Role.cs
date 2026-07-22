using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Role
{
    public long RoleIdPk { get; set; }

    public string? RoleName { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
