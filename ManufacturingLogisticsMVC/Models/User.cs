using System;
using System.Collections.Generic;

namespace ManufacturingLogisticsMVC.Models;

public partial class User
{
    public long UserIdPk { get; set; }

    public string? UserName { get; set; }

    public long? RoleIdFk { get; set; }

    public string? Password { get; set; }

    public long? UserAddressIdFk { get; set; }

    public string? Email { get; set; }

    public string? ContactNumber { get; set; }

    public DateTime? CreatedDateTime { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public long? CreatedByUserIdFk { get; set; }

    public long? UpdatedByUserIdFk { get; set; }

    public virtual ICollection<Address> AddressCreatedByUserIdFkNavigations { get; set; } = new List<Address>();

    public virtual ICollection<Address> AddressUpdatedByUserIdFkNavigations { get; set; } = new List<Address>();

    public virtual ICollection<Carrier> CarrierCreatedByUserIdFkNavigations { get; set; } = new List<Carrier>();

    public virtual ICollection<Carrier> CarrierUpdatedByUserIdFkNavigations { get; set; } = new List<Carrier>();

    public virtual ICollection<Catalog> CatalogCreatedByUserIdFkNavigations { get; set; } = new List<Catalog>();

    public virtual ICollection<Catalog> CatalogUpdatedByUserIdFkNavigations { get; set; } = new List<Catalog>();

    public virtual ICollection<Category> CategoryCreatedByUserIdFkNavigations { get; set; } = new List<Category>();

    public virtual ICollection<Category> CategoryUpdatedByUserIdFkNavigations { get; set; } = new List<Category>();

    public virtual ICollection<City> CityCreatedByUserIdFkNavigations { get; set; } = new List<City>();

    public virtual ICollection<City> CityUpdatedByUserIdFkNavigations { get; set; } = new List<City>();

    public virtual ICollection<Country> CountryCreatedByUserIdFkNavigations { get; set; } = new List<Country>();

    public virtual ICollection<Country> CountryUpdatedByUserIdFkNavigations { get; set; } = new List<Country>();

    public virtual User? CreatedByUserIdFkNavigation { get; set; }

    public virtual ICollection<Dc> DcCreatedByUserIdFkNavigations { get; set; } = new List<Dc>();

    public virtual ICollection<DcInventory> DcInventoryCreatedByUserIdFkNavigations { get; set; } = new List<DcInventory>();

    public virtual ICollection<DcInventory> DcInventoryUpdatedByUserIdFkNavigations { get; set; } = new List<DcInventory>();

    public virtual ICollection<DcReceiving> DcReceivingCreatedByUserIdFkNavigations { get; set; } = new List<DcReceiving>();

    public virtual ICollection<DcReceivingItem> DcReceivingItemCreatedByUserIdFkNavigations { get; set; } = new List<DcReceivingItem>();

    public virtual ICollection<DcReceivingItem> DcReceivingItemUpdatedByUserIdFkNavigations { get; set; } = new List<DcReceivingItem>();

    public virtual ICollection<DcReceiving> DcReceivingUpdatedByUserIdFkNavigations { get; set; } = new List<DcReceiving>();

    public virtual ICollection<Dc> DcUpdatedByUserIdFkNavigations { get; set; } = new List<Dc>();

    public virtual ICollection<Delivery> DeliveryCreatedByUserIdFkNavigations { get; set; } = new List<Delivery>();

    public virtual ICollection<Delivery> DeliveryUpdatedByUserIdFkNavigations { get; set; } = new List<Delivery>();

    public virtual ICollection<Dispatch> DispatchCreatedByUserIdFkNavigations { get; set; } = new List<Dispatch>();

    public virtual ICollection<DispatchItem> DispatchItemCreatedByUserIdFkNavigations { get; set; } = new List<DispatchItem>();

    public virtual ICollection<DispatchItem> DispatchItemUpdatedByUserIdFkNavigations { get; set; } = new List<DispatchItem>();

    public virtual ICollection<Dispatch> DispatchUpdatedByUserIdFkNavigations { get; set; } = new List<Dispatch>();

    public virtual ICollection<InventoryTransaction> InventoryTransactionCreatedByUserIdFkNavigations { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<InventoryTransaction> InventoryTransactionUpdatedByUserIdFkNavigations { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<User> InverseCreatedByUserIdFkNavigation { get; set; } = new List<User>();

    public virtual ICollection<User> InverseUpdatedByUserIdFkNavigation { get; set; } = new List<User>();

    public virtual ICollection<Location> LocationCreatedByUserIdFkNavigations { get; set; } = new List<Location>();

    public virtual ICollection<Location> LocationUpdatedByUserIdFkNavigations { get; set; } = new List<Location>();

    public virtual ICollection<Manager> ManagerCreatedByUserIdFkNavigations { get; set; } = new List<Manager>();

    public virtual ICollection<Manager> ManagerUpdatedByUserIdFkNavigations { get; set; } = new List<Manager>();

    public virtual ICollection<OrderPriority> OrderPriorityCreatedByUserIdFkNavigations { get; set; } = new List<OrderPriority>();

    public virtual ICollection<OrderPriority> OrderPriorityUpdatedByUserIdFkNavigations { get; set; } = new List<OrderPriority>();

    public virtual ICollection<Product> ProductCreatedByUserIdFkNavigations { get; set; } = new List<Product>();

    public virtual ICollection<ProductStoreMapping> ProductStoreMappingCreatedByUserIdFkNavigations { get; set; } = new List<ProductStoreMapping>();

    public virtual ICollection<ProductStoreMapping> ProductStoreMappingUpdatedByUserIdFkNavigations { get; set; } = new List<ProductStoreMapping>();

    public virtual ICollection<ProductSupplierMapping> ProductSupplierMappingCreatedByUserIdFkNavigations { get; set; } = new List<ProductSupplierMapping>();

    public virtual ICollection<ProductSupplierMapping> ProductSupplierMappingUpdatedByUserIdFkNavigations { get; set; } = new List<ProductSupplierMapping>();

    public virtual ICollection<Product> ProductUpdatedByUserIdFkNavigations { get; set; } = new List<Product>();

    public virtual ICollection<PurchaseOrder> PurchaseOrderApprovedByUserIdFkNavigations { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<PurchaseOrder> PurchaseOrderCreatedByUserIdFkNavigations { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItemCreatedByUserIdFkNavigations { get; set; } = new List<PurchaseOrderItem>();

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItemUpdatedByUserIdFkNavigations { get; set; } = new List<PurchaseOrderItem>();

    public virtual ICollection<PurchaseOrder> PurchaseOrderUpdatedByUserIdFkNavigations { get; set; } = new List<PurchaseOrder>();

    public virtual ICollection<Return> ReturnCreatedByUserIdFkNavigations { get; set; } = new List<Return>();

    public virtual ICollection<ReturnInspection> ReturnInspectionCreatedByUserIdFkNavigations { get; set; } = new List<ReturnInspection>();

    public virtual ICollection<ReturnInspection> ReturnInspectionUpdatedByUserIdFkNavigations { get; set; } = new List<ReturnInspection>();

    public virtual ICollection<ReturnItem> ReturnItemCreatedByUserIdFkNavigations { get; set; } = new List<ReturnItem>();

    public virtual ICollection<ReturnItem> ReturnItemUpdatedByUserIdFkNavigations { get; set; } = new List<ReturnItem>();

    public virtual ICollection<Return> ReturnUpdatedByUserIdFkNavigations { get; set; } = new List<Return>();

    public virtual ICollection<Role> RoleCreatedByUserIdFkNavigations { get; set; } = new List<Role>();

    public virtual Role? RoleIdFkNavigation { get; set; }

    public virtual ICollection<Role> RoleUpdatedByUserIdFkNavigations { get; set; } = new List<Role>();

    public virtual ICollection<Shipment> ShipmentCreatedByUserIdFkNavigations { get; set; } = new List<Shipment>();

    public virtual ICollection<ShipmentItem> ShipmentItemCreatedByUserIdFkNavigations { get; set; } = new List<ShipmentItem>();

    public virtual ICollection<ShipmentItem> ShipmentItemUpdatedByUserIdFkNavigations { get; set; } = new List<ShipmentItem>();

    public virtual ICollection<Shipment> ShipmentUpdatedByUserIdFkNavigations { get; set; } = new List<Shipment>();

    public virtual ICollection<State> StateCreatedByUserIdFkNavigations { get; set; } = new List<State>();

    public virtual ICollection<State> StateUpdatedByUserIdFkNavigations { get; set; } = new List<State>();

    public virtual ICollection<StorageType> StorageTypeCreatedByUserIdFkNavigations { get; set; } = new List<StorageType>();

    public virtual ICollection<StorageType> StorageTypeUpdatedByUserIdFkNavigations { get; set; } = new List<StorageType>();

    public virtual ICollection<StoreDemandLimit> StoreDemandLimitCreatedByUserIdFkNavigations { get; set; } = new List<StoreDemandLimit>();

    public virtual ICollection<StoreDemandLimit> StoreDemandLimitUpdatedByUserIdFkNavigations { get; set; } = new List<StoreDemandLimit>();

    public virtual ICollection<StoreOrder> StoreOrderCreatedByUserIdFkNavigations { get; set; } = new List<StoreOrder>();

    public virtual ICollection<StoreOrderItem> StoreOrderItemCreatedByUserIdFkNavigations { get; set; } = new List<StoreOrderItem>();

    public virtual ICollection<StoreOrderItem> StoreOrderItemUpdatedByUserIdFkNavigations { get; set; } = new List<StoreOrderItem>();

    public virtual ICollection<StoreOrder> StoreOrderUpdatedByUserIdFkNavigations { get; set; } = new List<StoreOrder>();

    public virtual ICollection<StoreProfile> StoreProfileCreatedByUserIdFkNavigations { get; set; } = new List<StoreProfile>();

    public virtual ICollection<StoreProfile> StoreProfileUpdatedByUserIdFkNavigations { get; set; } = new List<StoreProfile>();

    public virtual ICollection<Subcategory> SubcategoryCreatedByUserIdFkNavigations { get; set; } = new List<Subcategory>();

    public virtual ICollection<Subcategory> SubcategoryUpdatedByUserIdFkNavigations { get; set; } = new List<Subcategory>();

    public virtual ICollection<Supplier> SupplierCreatedByUserIdFkNavigations { get; set; } = new List<Supplier>();

    public virtual ICollection<SupplierProductRate> SupplierProductRateCreatedByUserIdFkNavigations { get; set; } = new List<SupplierProductRate>();

    public virtual ICollection<SupplierProductRate> SupplierProductRateUpdatedByUserIdFkNavigations { get; set; } = new List<SupplierProductRate>();

    public virtual ICollection<SupplierType> SupplierTypeCreatedByUserIdFkNavigations { get; set; } = new List<SupplierType>();

    public virtual ICollection<SupplierType> SupplierTypeUpdatedByUserIdFkNavigations { get; set; } = new List<SupplierType>();

    public virtual ICollection<Supplier> SupplierUpdatedByUserIdFkNavigations { get; set; } = new List<Supplier>();

    public virtual ICollection<TaxCategory> TaxCategoryCreatedByUserIdFkNavigations { get; set; } = new List<TaxCategory>();

    public virtual ICollection<TaxCategory> TaxCategoryUpdatedByUserIdFkNavigations { get; set; } = new List<TaxCategory>();

    public virtual User? UpdatedByUserIdFkNavigation { get; set; }

    public virtual Address? UserAddressIdFkNavigation { get; set; }
}
