using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class TaxCategory
{
    public long TaxCategoryIdPk { get; set; }

    public string? TaxCategoryName { get; set; }

    public int? TaxCategoryValue { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
