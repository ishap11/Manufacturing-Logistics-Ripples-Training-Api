using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Subcategory
{
    public long SubcategoryIdPk { get; set; }

    public string? SubcategoryName { get; set; }

    public long? CategoryIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual Category? CategoryIdFkNavigation { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
