using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Category
{
    public long CategoryIdPk { get; set; }

    public string? CategoryName { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<Subcategory> Subcategories { get; set; } = new List<Subcategory>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
