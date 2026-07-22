using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Product
{
    public long ProductIdPk { get; set; }

    public string? ProductName { get; set; }

    public long? SubcategoryIdFk { get; set; }

    public long? StorageTypeIdFk { get; set; }

    public long? TaxCategoryIdFk { get; set; }

    public long? UnitOfMeasurementIdFk { get; set; }

    public long? HsnCode { get; set; }

    public decimal? PackSize { get; set; }

    public decimal? ProductWeight { get; set; }

    public long? ProductStatusIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<DcInventory> DcInventories { get; set; } = new List<DcInventory>();

    public virtual ICollection<DcReceivingItem> DcReceivingItems { get; set; } = new List<DcReceivingItem>();

    public virtual ICollection<DispatchItem> DispatchItems { get; set; } = new List<DispatchItem>();

    public virtual ICollection<ProductStoreMapping> ProductStoreMappings { get; set; } = new List<ProductStoreMapping>();

    public virtual ICollection<ProductSupplierMapping> ProductSupplierMappings { get; set; } = new List<ProductSupplierMapping>();

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    public virtual ICollection<ReturnItem> ReturnItems { get; set; } = new List<ReturnItem>();

    public virtual StorageType? StorageTypeIdFkNavigation { get; set; }

    public virtual ICollection<StoreDemandLimit> StoreDemandLimits { get; set; } = new List<StoreDemandLimit>();

    public virtual ICollection<StoreOrderItem> StoreOrderItems { get; set; } = new List<StoreOrderItem>();

    public virtual Subcategory? SubcategoryIdFkNavigation { get; set; }

    public virtual ICollection<SupplierProductRate> SupplierProductRates { get; set; } = new List<SupplierProductRate>();

    public virtual TaxCategory? TaxCategoryIdFkNavigation { get; set; }

    public virtual Catalog? UnitOfMeasurementIdFkNavigation { get; set; }

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
