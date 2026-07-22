using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class SupplierProductRate
{
    public long SupplierProductRateIdPk { get; set; }

    public long? SupplierIdFk { get; set; }

    public long? ProductIdFk { get; set; }

    public decimal? BaseRate { get; set; }

    public decimal? SupplyingQuantity { get; set; }

    public DateTime? EffectiveFrom { get; set; }

    public DateTime? EffectiveTo { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Product? ProductIdFkNavigation { get; set; }

    public virtual Supplier? SupplierIdFkNavigation { get; set; }

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
