using Microsoft.EntityFrameworkCore;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models
{
    public class ManufacturingLogisticsDbContext : DbContext
    {
        public ManufacturingLogisticsDbContext(DbContextOptions<ManufacturingLogisticsDbContext> options)
            : base(options)
        {
        }

        // Entities
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Catalog> Catalogs { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Users> Users { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Subcategory> Subcategories { get; set; } = null!;
        public virtual DbSet<StorageType> StorageTypes { get; set; } = null!;
        public virtual DbSet<TaxCategory> TaxCategories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<SupplierType> SupplierTypes { get; set; } = null!;
        public virtual DbSet<Managers> Managers { get; set; } = null!;
        public virtual DbSet<Suppliers> Suppliers { get; set; } = null!;
        public virtual DbSet<SupplierProductRate> SupplierProductRates { get; set; } = null!;
        public virtual DbSet<ProductSupplierMapping> ProductSupplierMappings { get; set; } = null!;
        public virtual DbSet<ProductStoreMapping> ProductStoreMappings { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; } = null!;
        public virtual DbSet<Carriers> Carriers { get; set; } = null!;
        public virtual DbSet<Shipment> Shipments { get; set; } = null!;
        public virtual DbSet<ShipmentItem> ShipmentItems { get; set; } = null!;
        public virtual DbSet<DC> DCs { get; set; } = null!;
        public virtual DbSet<DcReceiving> DcReceivings { get; set; } = null!;
        public virtual DbSet<DcReceivingItem> DcReceivingItems { get; set; } = null!;
        public virtual DbSet<DcInventory> DcInventories { get; set; } = null!;
        public virtual DbSet<StoreProfiles> StoreProfiles { get; set; } = null!;
        public virtual DbSet<StoreDemandLimits> StoreDemandLimits { get; set; } = null!;
        public virtual DbSet<OrderPriority> OrderPriorities { get; set; } = null!;
        public virtual DbSet<StoreOrders> StoreOrders { get; set; } = null!;
        public virtual DbSet<StoreOrderItems> StoreOrderItems { get; set; } = null!;
        public virtual DbSet<Dispatch> Dispatches { get; set; } = null!;
        public virtual DbSet<DispatchItems> DispatchItems { get; set; } = null!;
        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<Return> Returns { get; set; } = null!;
        public virtual DbSet<ReturnItems> ReturnItems { get; set; } = null!;
        public virtual DbSet<ReturnInspection> ReturnInspections { get; set; } = null!;
        public virtual DbSet<InventoryTransactions> InventoryTransactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Country
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");
                entity.HasKey(e => e.CountryIdPk);
                entity.Property(e => e.CountryIdPk).HasColumnName("Country_ID_Pk");
                entity.Property(e => e.CountryName).HasColumnName("Country_Name").HasMaxLength(100);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // State
            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");
                entity.HasKey(e => e.StateIdPk);
                entity.Property(e => e.StateIdPk).HasColumnName("State_ID_Pk");
                entity.Property(e => e.StateName).HasColumnName("State_Name").HasMaxLength(100);
                entity.Property(e => e.CountryIdFk).HasColumnName("Country_ID_Fk");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Country)
                    .WithMany()
                    .HasForeignKey(d => d.CountryIdFk);
            });

            // City
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");
                entity.HasKey(e => e.CityIdPk);
                entity.Property(e => e.CityIdPk).HasColumnName("City_ID_Pk");
                entity.Property(e => e.CityName).HasColumnName("City_Name").HasMaxLength(100);
                entity.Property(e => e.StateIdFk).HasColumnName("State_ID_Fk");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.State)
                    .WithMany()
                    .HasForeignKey(d => d.StateIdFk);
            });

            // Address
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");
                entity.HasKey(e => e.AddressIdPk);
                entity.Property(e => e.AddressIdPk).HasColumnName("Address_ID_Pk");
                entity.Property(e => e.AddressLine1).HasColumnName("Address_Line1").HasMaxLength(200);
                entity.Property(e => e.AddressLine2).HasColumnName("Address_Line2").HasMaxLength(200);
                entity.Property(e => e.CityIdFk).HasColumnName("City_ID_Fk");
                entity.Property(e => e.Pincode).HasColumnName("Pincode").HasMaxLength(20);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.City)
                    .WithMany()
                    .HasForeignKey(d => d.CityIdFk);
            });

            // Catalog
            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.ToTable("Catalog");
                entity.HasKey(e => e.CatalogIdPk);
                entity.Property(e => e.CatalogIdPk).HasColumnName("Catalog_Id_Pk");
                entity.Property(e => e.CatalogType).HasColumnName("Catalog_Type").HasMaxLength(100);
                entity.Property(e => e.CatalogKey).HasColumnName("Catalog_Key").HasMaxLength(100);
                entity.Property(e => e.CatalogValue).HasColumnName("Catalog_Value").HasMaxLength(100);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
                entity.HasKey(e => e.RoleIdPk);
                entity.Property(e => e.RoleIdPk).HasColumnName("Role_Id_Pk");
                entity.Property(e => e.RoleName).HasColumnName("Role_Name").HasMaxLength(100);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // Users
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.UserIdPk);
                entity.Property(e => e.UserIdPk).HasColumnName("User_ID_Pk");
                entity.Property(e => e.UserName).HasColumnName("User_Name").HasMaxLength(100);
                entity.Property(e => e.RoleIdFk).HasColumnName("Role_Id_Fk");
                entity.Property(e => e.Password).HasColumnName("Password").HasMaxLength(255);
                entity.Property(e => e.UserAddressIdFk).HasColumnName("User_Address_Id_FK");
                entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(100);
                entity.Property(e => e.ContactNumber).HasColumnName("Contact_Number").HasMaxLength(15);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleIdFk);

                entity.HasOne(d => d.UserAddress)
                    .WithMany()
                    .HasForeignKey(d => d.UserAddressIdFk);
            });

            // Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(e => e.CategoryIdPk);
                entity.Property(e => e.CategoryIdPk).HasColumnName("Category_ID_Pk");
                entity.Property(e => e.CategoryName).HasColumnName("Category_Name").HasMaxLength(100);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // Subcategory
            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("Subcategory");
                entity.HasKey(e => e.SubcategoryIdPk);
                entity.Property(e => e.SubcategoryIdPk).HasColumnName("Subcategory_ID_Pk");
                entity.Property(e => e.SubcategoryName).HasColumnName("Subcategory_Name").HasMaxLength(100);
                entity.Property(e => e.CategoryIdFk).HasColumnName("Category_ID_Fk");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryIdFk);
            });

            // StorageType
            modelBuilder.Entity<StorageType>(entity =>
            {
                entity.ToTable("Storage_Type");
                entity.HasKey(e => e.StorageTypeIdPk);
                entity.Property(e => e.StorageTypeIdPk).HasColumnName("Storage_Type_ID_Pk");
                entity.Property(e => e.StorageTypeName).HasColumnName("Storage_Type_Name").HasMaxLength(100);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // TaxCategory
            modelBuilder.Entity<TaxCategory>(entity =>
            {
                entity.ToTable("Tax_Category");
                entity.HasKey(e => e.TaxCategoryIdPk);
                entity.Property(e => e.TaxCategoryIdPk).HasColumnName("Tax_Category_ID_Pk");
                entity.Property(e => e.TaxCategoryName).HasColumnName("Tax_Category_name").HasMaxLength(100);
                entity.Property(e => e.TaxCategoryValue).HasColumnName("Tax_Category_Value");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(e => e.ProductIdPk);
                entity.Property(e => e.ProductIdPk).HasColumnName("Product_ID_Pk");
                entity.Property(e => e.ProductName).HasColumnName("Product_Name").HasMaxLength(150);
                entity.Property(e => e.SubcategoryIDFk).HasColumnName("Subcategory_ID_Fk");
                entity.Property(e => e.StorageTypeIdFk).HasColumnName("Storage_Type_Id_Fk");
                entity.Property(e => e.TaxCategoryIdFk).HasColumnName("Tax_Category_Id_Fk");
                entity.Property(e => e.UnitOfMeasurementIdFk).HasColumnName("Unit_Of_Measurement_Id_Fk");
                entity.Property(e => e.HsnCode).HasColumnName("HSN_Code");
                entity.Property(e => e.PackSize).HasColumnName("Pack_Size").HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ProductWeight).HasColumnName("Product_Weight").HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ProductStatusIdFk).HasColumnName("Product_Status_Id_Fk");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.UnitOfMeasurement)
                    .WithMany()
                    .HasForeignKey(d => d.UnitOfMeasurementIdFk);
            });

            // SupplierType
            modelBuilder.Entity<SupplierType>(entity =>
            {
                entity.ToTable("Supplier_Type");
                entity.HasKey(e => e.SupplierTypeIdPk);
                entity.Property(e => e.SupplierTypeIdPk).HasColumnName("Supplier_Type_ID_Pk");
                entity.Property(e => e.SupplierTypeName).HasColumnName("Supplier_Type_Name").HasMaxLength(100);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // Managers
            modelBuilder.Entity<Managers>(entity =>
            {
                entity.ToTable("Managers");
                entity.HasKey(e => e.ManagersIdPk);
                entity.Property(e => e.ManagersIdPk).HasColumnName("Managers_Id_Pk");
                entity.Property(e => e.ManagersName).HasColumnName("Managers_Name").HasMaxLength(100);
                entity.Property(e => e.ManagersContactCode).HasColumnName("Managers_Contact_Code").HasMaxLength(10);
                entity.Property(e => e.ManagersContactPhone).HasColumnName("Managers_Contact_Phone").HasMaxLength(20);
                entity.Property(e => e.ManagersEmail).HasColumnName("Managers__Email").HasMaxLength(100);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // Suppliers
            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.ToTable("Suppliers");
                entity.HasKey(e => e.SupplierId);
                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");
                entity.Property(e => e.CompanyName).HasColumnName("Company_Name").HasMaxLength(100).IsRequired();
                entity.Property(e => e.ContactPerson).HasColumnName("Contact_Person").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Age).HasColumnName("Age").IsRequired();
                entity.Property(e => e.PhoneNumber).HasColumnName("Phone_Number").HasMaxLength(20).IsRequired();
                entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
                entity.Property(e => e.SupplierTypeId).HasColumnName("Supplier_Type_Id").IsRequired();
                entity.Property(e => e.AddressId).HasColumnName("Address_Id").IsRequired();
                entity.Property(e => e.CreatedDate).HasColumnName("Created_Date").IsRequired();
                entity.Property(e => e.UpdatedDate).HasColumnName("Updated_Date").IsRequired();

                entity.HasOne(d => d.SupplierType)
                    .WithMany()
                    .HasForeignKey(d => d.SupplierTypeId);

                entity.HasOne(d => d.Address)
                    .WithMany()
                    .HasForeignKey(d => d.AddressId);
            });

            // SupplierProductRate
            modelBuilder.Entity<SupplierProductRate>(entity =>
            {
                entity.HasKey(e => e.SupplierProductRateIdPk).HasName("PK__Supplier__E9B547A24B941FF3");

                entity.ToTable("Supplier_Product_Rate");

                entity.Property(e => e.SupplierProductRateIdPk)
                    .ValueGeneratedNever()
                    .HasColumnName("Supplier_Product_Rate_ID_Pk");
                entity.Property(e => e.BaseRate)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Base_Rate");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_DateTime");
                entity.Property(e => e.EffectiveFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("Effective_From");
                entity.Property(e => e.EffectiveTo)
                    .HasColumnType("datetime")
                    .HasColumnName("Effective_To");
                entity.Property(e => e.ProductSupplierIdFk).HasColumnName("Product_Supplier_ID_Fk");
                entity.Property(e => e.SupplyingQuantity)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Supplying_Quantity");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
                entity.Property(e => e.UpdatedDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_DateTime");
            });

            // ProductSupplierMapping
            modelBuilder.Entity<ProductSupplierMapping>(entity =>
            {
                entity.ToTable("Product_Supplier_Mapping");
                entity.HasKey(e => e.ProductSupplierIdPk);
                entity.Property(e => e.ProductSupplierIdPk).HasColumnName("Product_Supplier_ID_Pk");
                entity.Property(e => e.ProductIdFk).HasColumnName("Product_ID_Fk");
                entity.Property(e => e.SupplierIdFk).HasColumnName("Supplier_ID_FK");
                entity.Property(e => e.LeadTime).HasColumnName("Lead_Time");
                entity.Property(e => e.EffectiveFrom).HasColumnName("Effective_From");
                entity.Property(e => e.EffectiveTo).HasColumnName("Effective_To");
                entity.Property(e => e.ProductSupplierStatusIdFk).HasColumnName("Product_Supplier_Status_Id_Fk");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductIdFk);

                entity.HasOne(d => d.Supplier)
                    .WithMany()
                    .HasForeignKey(d => d.SupplierIdFk);

                entity.HasOne(d => d.ProductSupplierStatus)
                    .WithMany()
                    .HasForeignKey(d => d.ProductSupplierStatusIdFk);
            });

            // ProductStoreMapping
            modelBuilder.Entity<ProductStoreMapping>(entity =>
            {
                entity.ToTable("Product_Store_Mapping");
                entity.HasKey(e => e.ProductStoreIdPk);
                entity.Property(e => e.ProductStoreIdPk).HasColumnName("Product_Store_ID_PK");
                entity.Property(e => e.ProductIdFk).HasColumnName("Product_ID_Fk");
                entity.Property(e => e.StoreIdFk).HasColumnName("Store_ID_Fk");
                entity.Property(e => e.MinQuantity).HasColumnName("Min_Quantity").HasColumnType("decimal(10, 2)");
                entity.Property(e => e.MaxQuantity).HasColumnName("Max_Quantity").HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ReorderPoint).HasColumnName("Reorder_Point").HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ProductStoreStatusIdFk).HasColumnName("Product_Store_Status_Id_Fk");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductIdFk);

                entity.HasOne(d => d.Store)
                    .WithMany()
                    .HasForeignKey(d => d.StoreIdFk);

                entity.HasOne(d => d.ProductStoreStatus)
                    .WithMany()
                    .HasForeignKey(d => d.ProductStoreStatusIdFk);
            });

            // Location
            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");
                entity.HasKey(e => e.LocationIdPk);
                entity.Property(e => e.LocationIdPk).HasColumnName("Location_Id_PK");
                entity.Property(e => e.LocationName).HasColumnName("Location_Name").HasMaxLength(100);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // PurchaseOrder
            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.ToTable("Purchase_Orders");
                entity.HasKey(e => e.PurchaseOrderIdPk);
                entity.Property(e => e.PurchaseOrderIdPk).HasColumnName("Purchase_Order_Id_PK");
                entity.Property(e => e.SupplierIdFk).HasColumnName("Supplier_Id_FK");
                entity.Property(e => e.OrderStatusIdFk).HasColumnName("Order_Status_Id_FK");
                entity.Property(e => e.CurrencyIdFk).HasColumnName("Currency_Id_FK");
                entity.Property(e => e.PoDate).HasColumnName("PO_Date").HasColumnType("date");
                entity.Property(e => e.ExpectedDeliveryDate).HasColumnName("Expected_Delivery_Date").HasColumnType("date");
                entity.Property(e => e.ApprovedByUserIdFk).HasColumnName("Approved_By_User_Id_FK");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Supplier)
                    .WithMany()
                    .HasForeignKey(d => d.SupplierIdFk);

                entity.HasOne(d => d.OrderStatus)
                    .WithMany()
                    .HasForeignKey(d => d.OrderStatusIdFk);

                entity.HasOne(d => d.Currency)
                    .WithMany()
                    .HasForeignKey(d => d.CurrencyIdFk);

                entity.HasOne(d => d.ApprovedByUser)
                    .WithMany()
                    .HasForeignKey(d => d.ApprovedByUserIdFk);
            });

            // PurchaseOrderItem
            modelBuilder.Entity<PurchaseOrderItem>(entity =>
            {
                entity.HasKey(e => e.PoItemIdPk).HasName("PK__Purchase__3F88059D52B5F42F");

                entity.ToTable("Purchase_Order_Items");

                entity.Property(e => e.PoItemIdPk)
                    .ValueGeneratedNever()
                    .HasColumnName("PO_Item_Id_PK");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.CreatedDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_DateTime");
                entity.Property(e => e.ProductSupplierIdFk).HasColumnName("Product_Supplier_Id_FK");
                entity.Property(e => e.PurchaseOrderIdFk).HasColumnName("Purchase_Order_Id_FK");
                entity.Property(e => e.PurchaseQuantity).HasColumnName("Purchase_Quantity");
                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Unit_Price");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
                entity.Property(e => e.UpdatedDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_DateTime");
                entity.HasOne(d => d.PurchaseOrder)
      .WithMany(p => p.PurchaseOrderItems)
      .HasForeignKey(d => d.PurchaseOrderIdFk);
            });

            // Carriers
            modelBuilder.Entity<Carriers>(entity =>
            {
                entity.ToTable("Carriers");
                entity.HasKey(e => e.CarrierIdPk);
                entity.Property(e => e.CarrierIdPk).HasColumnName("Carrier_Id_PK");
                entity.Property(e => e.CarrierName).HasColumnName("Carrier_Name").HasMaxLength(150);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // Shipment
            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("Shipments");
                entity.HasKey(e => e.ShipmentIdPk);
                entity.Property(e => e.ShipmentIdPk).HasColumnName("Shipment_Id_PK");
                entity.Property(e => e.PurchaseOrderIdFk).HasColumnName("Purchase_Order_Id_FK");
                entity.Property(e => e.ShipmentStatusIdFk).HasColumnName("Shipment_Status_Id_FK");
                entity.Property(e => e.TransportModeIdFk).HasColumnName("Transport_Mode_Id_FK");
                entity.Property(e => e.CarrierIdFk).HasColumnName("Carrier_Id_FK");
                entity.Property(e => e.TrackingNumber).HasColumnName("Tracking_Number").HasMaxLength(100);
                entity.Property(e => e.DispatchDate).HasColumnName("Dispatch_Date").HasColumnType("date");
                entity.Property(e => e.EstimatedArrival).HasColumnName("Estimated_Arrival").HasColumnType("date");
                entity.Property(e => e.ActualArrival).HasColumnName("Actual_Arrival").HasColumnType("date");
                entity.Property(e => e.CurrentLocationIdFk).HasColumnName("Current_Location_Id_FK");
                entity.Property(e => e.OriginLocationIdFk).HasColumnName("Origin_Location_Id_FK");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // ShipmentItem
            modelBuilder.Entity<ShipmentItem>(entity =>
            {
                entity.ToTable("Shipment_Items");
                entity.HasKey(e => e.ShipmentItemIdPk);
                entity.Property(e => e.ShipmentItemIdPk).HasColumnName("Shipment_Item_Id_PK");
                entity.Property(e => e.ShipmentIdFk).HasColumnName("Shipment_Id_FK");
                entity.Property(e => e.POItemIdFk).HasColumnName("PO_Item_Id_FK");
                entity.Property(e => e.ShippedQuantity).HasColumnName("Shipped_Quantity");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.ShipmentItems)
                    .HasForeignKey(d => d.ShipmentIdFk);

                entity.HasOne(d => d.POItem)
                    .WithMany()
                    .HasForeignKey(d => d.POItemIdFk);
            });

            // DC
            modelBuilder.Entity<DC>(entity =>
            {
                entity.ToTable("DC");
                entity.HasKey(e => e.DCIdPk);
                entity.Property(e => e.DCIdPk).HasColumnName("DC_Id_Pk");
                entity.Property(e => e.DCName).HasColumnName("DC_Name").HasMaxLength(150);
                entity.Property(e => e.DCAddressIdFk).HasColumnName("DC_Address_Id_Fk");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // DcReceiving
            modelBuilder.Entity<DcReceiving>(entity =>
            {
                entity.ToTable("DC_Receiving");
                entity.HasKey(e => e.DcReceivingIdPk);
                entity.Property(e => e.DcReceivingIdPk).HasColumnName("DC_Receiving_Id_Pk");
                entity.Property(e => e.DcIdFk).HasColumnName("DC_Id_Fk");
                entity.Property(e => e.ShipmentIdFk).HasColumnName("Shipment_Id_Fk");
                entity.Property(e => e.ReceivingStatusIdFk).HasColumnName("Receiving_Status_Id_Fk");
                entity.Property(e => e.Remarks).HasColumnName("Remarks").HasMaxLength(255);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Dc)
                    .WithMany()
                    .HasForeignKey(d => d.DcIdFk);

                entity.HasOne(d => d.Shipment)
                    .WithMany()
                    .HasForeignKey(d => d.ShipmentIdFk);

                entity.HasOne(d => d.ReceivingStatus)
                    .WithMany()
                    .HasForeignKey(d => d.ReceivingStatusIdFk);
            });

            // DcReceivingItem
            modelBuilder.Entity<DcReceivingItem>(entity =>
            {
                entity.ToTable("DC_Receiving_Items");
                entity.HasKey(e => e.DcReceivingItemsIdPk);
                entity.Property(e => e.DcReceivingItemsIdPk).HasColumnName("DC_Receiving_Items_Id_Pk");
                entity.Property(e => e.DcReceivingIdFk).HasColumnName("DC_Receiving_Id_Fk");
                entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_Fk");
                entity.Property(e => e.ReceivedQuantity).HasColumnName("Received_Quantity");
                entity.Property(e => e.AcceptedQuantity).HasColumnName("Accepted_Quantity");
                entity.Property(e => e.DamagedQuantity).HasColumnName("Damaged_Quantity");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.DcReceiving)
                    .WithMany(p => p.DcReceivingItems)
                    .HasForeignKey(d => d.DcReceivingIdFk);

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductIdFk);
            });

            // DcInventory
            modelBuilder.Entity<DcInventory>(entity =>
            {
                entity.ToTable("DC_Inventory");
                entity.HasKey(e => e.DcInventoryIdPk);
                entity.Property(e => e.DcInventoryIdPk).HasColumnName("DC_Inventory_Id_Pk");
                entity.Property(e => e.DcIdFk).HasColumnName("DC_Id_Fk");
                entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_Fk");
                entity.Property(e => e.AvailableQuantity).HasColumnName("Available_Quantity");
                entity.Property(e => e.DamagedQuantity).HasColumnName("Damaged_Quantity");
                entity.Property(e => e.BlockedQuantity).HasColumnName("Blocked_Quantity");
                entity.Property(e => e.ReservedQuantity).HasColumnName("Reserved_Quantity");
                entity.Property(e => e.IntransitQuantity).HasColumnName("Intransit_Quantity");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Dc)
                    .WithMany()
                    .HasForeignKey(d => d.DcIdFk);

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductIdFk);
            });

            // StoreProfiles
            modelBuilder.Entity<StoreProfiles>(entity =>
            {
                entity.ToTable("Store_Profiles");
                entity.HasKey(e => e.StoreIdPk);
                entity.Property(e => e.StoreIdPk).HasColumnName("Store_Id_PK");
                entity.Property(e => e.StoreName).HasColumnName("Store_Name").HasMaxLength(100);
                entity.Property(e => e.ManagersIdFk).HasColumnName("Managers_Id_Fk");
                entity.Property(e => e.AddressIdFk).HasColumnName("Address_Id_FK");
                entity.Property(e => e.StoreStatusIdFk).HasColumnName("Store_Status_Id_FK");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Manager)
                    .WithMany()
                    .HasForeignKey(d => d.ManagersIdFk);

                entity.HasOne(d => d.Address)
                    .WithMany()
                    .HasForeignKey(d => d.AddressIdFk);

                entity.HasOne(d => d.StoreStatus)
                    .WithMany()
                    .HasForeignKey(d => d.StoreStatusIdFk);
            });

            // StoreDemandLimits
            modelBuilder.Entity<StoreDemandLimits>(entity =>
            {
                entity.ToTable("Store_Demand_Limits");
                entity.HasKey(e => e.LimitIdPk);
                entity.Property(e => e.LimitIdPk).HasColumnName("Limit_Id_PK");
                entity.Property(e => e.StoreIdFk).HasColumnName("Store_Id_FK");
                entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_FK");
                entity.Property(e => e.MinOrderLevel).HasColumnName("Min_Order_Level");
                entity.Property(e => e.MaxOrderLevel).HasColumnName("Max_Order_Level");
                entity.Property(e => e.EffectiveFromDate).HasColumnName("Effective_From_Date").HasColumnType("date");
                entity.Property(e => e.EffectiveToDate).HasColumnName("Effective_To_Date").HasColumnType("date");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Store)
                    .WithMany()
                    .HasForeignKey(d => d.StoreIdFk);

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductIdFk);
            });

            // OrderPriority
            modelBuilder.Entity<OrderPriority>(entity =>
            {
                entity.ToTable("Order_Priority");
                entity.HasKey(e => e.OrderPriorityIdPk);
                entity.Property(e => e.OrderPriorityIdPk).HasColumnName("Order_Priority_Id_PK");
                entity.Property(e => e.PriorityName).HasColumnName("Priority_Name").HasMaxLength(50);
                entity.Property(e => e.PriorityDescription).HasColumnName("Priority_Description").HasMaxLength(255);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            });

            // StoreOrders
            modelBuilder.Entity<StoreOrders>(entity =>
            {
                entity.ToTable("Store_Orders");
                entity.HasKey(e => e.StoreOrdersIdPk);
                entity.Property(e => e.StoreOrdersIdPk).HasColumnName("Store_Orders_Id_PK");
                entity.Property(e => e.StoreIdFk).HasColumnName("Store_Id_FK");
                entity.Property(e => e.OrderStatusIdFk).HasColumnName("Order_Status_Id_FK");
                entity.Property(e => e.RequestedDeliveryDate).HasColumnName("Requested_Delivery_Date").HasColumnType("date");
                entity.Property(e => e.ExpectedDeliveryDate).HasColumnName("Expected_Delivery_Date").HasColumnType("date");
                entity.Property(e => e.OrderPriorityIdFk).HasColumnName("Order_Priority_Id_FK");
                entity.Property(e => e.TotalOrderValue).HasColumnName("Total_Order_Value").HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Store)
                    .WithMany()
                    .HasForeignKey(d => d.StoreIdFk);

                entity.HasOne(d => d.OrderStatus)
                    .WithMany()
                    .HasForeignKey(d => d.OrderStatusIdFk);

                entity.HasOne(d => d.OrderPriority)
                    .WithMany()
                    .HasForeignKey(d => d.OrderPriorityIdFk);
            });

            // StoreOrderItems
            modelBuilder.Entity<StoreOrderItems>(entity =>
            {
                entity.ToTable("Store_Order_Items");
                entity.HasKey(e => e.StoreOrderItemsIdPk);
                entity.Property(e => e.StoreOrderItemsIdPk).HasColumnName("Store_Order_Items_Id_PK");
                entity.Property(e => e.StoreOrdersIdFk).HasColumnName("Store_Orders_Id_FK");
                entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_FK");
                entity.Property(e => e.RequestedQuantity).HasColumnName("Requested_Quantity");
                entity.Property(e => e.AllocatedQuantity).HasColumnName("Allocated_Quantity");
                entity.Property(e => e.AllocationNotes).HasColumnName("Allocation_Notes").HasMaxLength(255);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.StoreOrder)
                    .WithMany()
                    .HasForeignKey(d => d.StoreOrdersIdFk);

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductIdFk);
            });

            // Dispatch
            modelBuilder.Entity<Dispatch>(entity =>
            {
                entity.ToTable("Dispatch");
                entity.HasKey(e => e.DispatchIdPk);
                entity.Property(e => e.DispatchIdPk).HasColumnName("Dispatch_Id_PK");
                entity.Property(e => e.DcIdFk).HasColumnName("Dc_Id_FK");
                entity.Property(e => e.StoreIdFk).HasColumnName("Store_Id_FK");
                entity.Property(e => e.DispatchDate).HasColumnName("Dispatch_Date").HasColumnType("date");
                entity.Property(e => e.DispatchStatusIdFk).HasColumnName("Dispatch_Status_Id_FK");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Dc)
                    .WithMany()
                    .HasForeignKey(d => d.DcIdFk);

                entity.HasOne(d => d.Store)
                    .WithMany()
                    .HasForeignKey(d => d.StoreIdFk);

                entity.HasOne(d => d.DispatchStatus)
                    .WithMany()
                    .HasForeignKey(d => d.DispatchStatusIdFk);
            });

            // DispatchItems
            modelBuilder.Entity<DispatchItems>(entity =>
            {
                entity.ToTable("Dispatch_Items");
                entity.HasKey(e => e.DispatchItemIdPk);
                entity.Property(e => e.DispatchItemIdPk).HasColumnName("Dispatch_Item_Id_PK");
                entity.Property(e => e.DispatchIdFk).HasColumnName("Dispatch_Id_FK");
                entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_FK");
                entity.Property(e => e.DispatchedQuantity).HasColumnName("Dispatched_Quantity");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Dispatch)
                    .WithMany()
                    .HasForeignKey(d => d.DispatchIdFk);

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductIdFk);
            });

            // Delivery
            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Delivery");
                entity.HasKey(e => e.DeliveryIdPk);
                entity.Property(e => e.DeliveryIdPk).HasColumnName("Delivery_Id_PK");
                entity.Property(e => e.DispatchIdFk).HasColumnName("Dispatch_Id_FK");
                entity.Property(e => e.DeliveryDate).HasColumnName("Delivery_Date").HasColumnType("date");
                entity.Property(e => e.ReceivedByManagersIdFk).HasColumnName("Received_By_Managers_Id_FK");
                entity.Property(e => e.DeliveryStatusIdFk).HasColumnName("Delivery_Status_Id_FK");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Dispatch)
                    .WithMany()
                    .HasForeignKey(d => d.DispatchIdFk);

                entity.HasOne(d => d.ReceivedByManager)
                    .WithMany()
                    .HasForeignKey(d => d.ReceivedByManagersIdFk);

                entity.HasOne(d => d.DeliveryStatus)
                    .WithMany()
                    .HasForeignKey(d => d.DeliveryStatusIdFk);
            });

            // Return
            modelBuilder.Entity<Return>(entity =>
            {
                entity.ToTable("Return");
                entity.HasKey(e => e.ReturnIdPk);
                entity.Property(e => e.ReturnIdPk).HasColumnName("Return_Id_PK");
                entity.Property(e => e.ReturnRequestNumber).HasColumnName("Return_Request_Number").HasMaxLength(50);
                entity.Property(e => e.StoreIdFk).HasColumnName("Store_Id_FK");
                entity.Property(e => e.DcIdFk).HasColumnName("Dc_Id_FK");
                entity.Property(e => e.ReturnDate).HasColumnName("Return_Date").HasColumnType("date");
                entity.Property(e => e.ReturnStatusIdFk).HasColumnName("Return_Status_Id_FK");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Store)
                    .WithMany()
                    .HasForeignKey(d => d.StoreIdFk);

                entity.HasOne(d => d.Dc)
                    .WithMany()
                    .HasForeignKey(d => d.DcIdFk);

                entity.HasOne(d => d.ReturnStatus)
                    .WithMany()
                    .HasForeignKey(d => d.ReturnStatusIdFk);
            });

            // ReturnItems
            modelBuilder.Entity<ReturnItems>(entity =>
            {
                entity.ToTable("Return_Items");
                entity.HasKey(e => e.ReturnItemIdPk);
                entity.Property(e => e.ReturnItemIdPk).HasColumnName("Return_Item_Id_PK");
                entity.Property(e => e.ReturnIdFk).HasColumnName("Return_Id_FK");
                entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_FK");
                entity.Property(e => e.ReturnedQuantity).HasColumnName("Returned_Quantity");
                entity.Property(e => e.ReturnReason).HasColumnName("Return_Reason").HasMaxLength(150);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Return)
                    .WithMany()
                    .HasForeignKey(d => d.ReturnIdFk);

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductIdFk);
            });

            // ReturnInspection
            modelBuilder.Entity<ReturnInspection>(entity =>
            {
                entity.ToTable("Return_Inspection");
                entity.HasKey(e => e.InspectionIdPk);
                entity.Property(e => e.InspectionIdPk).HasColumnName("Inspection_Id_PK");
                entity.Property(e => e.ReturnIdFk).HasColumnName("Return_Id_FK");
                entity.Property(e => e.InspectedQuantity).HasColumnName("Inspected_Quantity");
                entity.Property(e => e.DamagedQuantity).HasColumnName("Damaged_Quantity");
                entity.Property(e => e.AcceptedQuantity).HasColumnName("Accepted_Quantity");
                entity.Property(e => e.Remarks).HasColumnName("Remarks").HasMaxLength(255);
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Return)
                    .WithMany()
                    .HasForeignKey(d => d.ReturnIdFk);
            });

            // InventoryTransactions
            modelBuilder.Entity<InventoryTransactions>(entity =>
            {
                entity.ToTable("Inventory_Transactions");
                entity.HasKey(e => e.InventoryTransactionIdPk);
                entity.Property(e => e.InventoryTransactionIdPk).HasColumnName("Inventory_Transaction_Id_PK");
                entity.Property(e => e.DcIdFk).HasColumnName("Dc_Id_FK");
                entity.Property(e => e.InspectionIdFk).HasColumnName("Inspection_Id_FK");
                entity.Property(e => e.QuantityChange).HasColumnName("Quantity_Change");
                entity.Property(e => e.TransactionTypeIdFk).HasColumnName("Transaction_Type_Id_FK");
                entity.Property(e => e.CreatedDateTime).HasColumnName("Created_DateTime");
                entity.Property(e => e.UpdatedDateTime).HasColumnName("Updated_DateTime");
                entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
                entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");

                entity.HasOne(d => d.Dc)
                    .WithMany()
                    .HasForeignKey(d => d.DcIdFk);

                entity.HasOne(d => d.ReturnInspection)
                    .WithMany()
                    .HasForeignKey(d => d.InspectionIdFk);

                entity.HasOne(d => d.TransactionType)
                    .WithMany()
                    .HasForeignKey(d => d.TransactionTypeIdFk);
            });
        }
    }
}
