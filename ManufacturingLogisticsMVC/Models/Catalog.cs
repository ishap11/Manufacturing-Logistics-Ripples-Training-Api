using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class Catalog
{
    public long CatalogIdPk { get; set; }

    public string? CatalogType { get; set; }

    public string? CatalogKey { get; set; }

    public string? CatalogValue { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<DcReceiving> DcReceivings { get; set; } = new List<DcReceiving>();

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<Dispatch> Dispatches { get; set; } = new List<Dispatch>();

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<ProductStoreMapping> ProductStoreMappings { get; set; } = new List<ProductStoreMapping>();

    public virtual ICollection<ProductSupplierMapping> ProductSupplierMappings { get; set; } = new List<ProductSupplierMapping>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<PurchaseOrder> PurchaseOrderCurrencyIdFkNavigations { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<PurchaseOrder> PurchaseOrderOrderStatusIdFkNavigations { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<Return> Returns { get; set; } = new List<Return>();

    public virtual ICollection<Shipment> ShipmentShipmentStatusIdFkNavigations { get; set; } = new List<Shipment>();

    public virtual ICollection<Shipment> ShipmentTransportModeIdFkNavigations { get; set; } = new List<Shipment>();

    public virtual ICollection<StoreOrder> StoreOrders { get; set; } = new List<StoreOrder>();

    public virtual ICollection<StoreProfile> StoreProfiles { get; set; } = new List<StoreProfile>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }
}
