using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class ProductStoreMapping
{
    public long ProductStoreIdPk { get; set; }

    public long? ProductIdFk { get; set; }

    public long? StoreIdFk { get; set; }

    public decimal? MinQuantity { get; set; }

    public decimal? MaxQuantity { get; set; }

    public decimal? ReorderPoint { get; set; }

    public long? ProductStoreStatusIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Product? ProductIdFkNavigation { get; set; }

    public virtual Catalog? ProductStoreStatusIdFkNavigation { get; set; }

    public virtual StoreProfile? StoreIdFkNavigation { get; set; }

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
