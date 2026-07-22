using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Supplier
{
    public long SupplierIdPk { get; set; }

    public string? SupplierName { get; set; }

    public long? SupplierTypeIdFk { get; set; }

    public long? CurrencyIdFk { get; set; }

    public long? GstNumber { get; set; }

    public long? ManagersIdFk { get; set; }

    public long? SupplierStatusIdFk { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual Catalog? CurrencyIdFkNavigation { get; set; }

    public virtual Manager? ManagersIdFkNavigation { get; set; }

    public virtual ICollection<ProductSupplierMapping> ProductSupplierMappings { get; set; } = new List<ProductSupplierMapping>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<SupplierProductRate> SupplierProductRates { get; set; } = new List<SupplierProductRate>();

    public virtual SupplierType? SupplierTypeIdFkNavigation { get; set; }

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
