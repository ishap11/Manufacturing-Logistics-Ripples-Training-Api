using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class SupplierType
{
    public long SupplierTypeIdPk { get; set; }

    public string? SupplierTypeName { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
