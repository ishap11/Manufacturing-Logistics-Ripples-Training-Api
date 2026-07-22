using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ManufacturingLogisticsMVC.Models;

public partial class ManufacturingLogisticsDbContext : DbContext
{
    public ManufacturingLogisticsDbContext()
    {
    }

    public ManufacturingLogisticsDbContext(DbContextOptions<ManufacturingLogisticsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Carrier> Carriers { get; set; }

    public virtual DbSet<Catalog> Catalogs { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Dc> Dcs { get; set; }

    public virtual DbSet<DcInventory> DcInventories { get; set; }

    public virtual DbSet<DcReceiving> DcReceivings { get; set; }

    public virtual DbSet<DcReceivingItem> DcReceivingItems { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Dispatch> Dispatches { get; set; }

    public virtual DbSet<DispatchItem> DispatchItems { get; set; }

    public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<OrderPriority> OrderPriorities { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductStoreMapping> ProductStoreMappings { get; set; }

    public virtual DbSet<ProductSupplierMapping> ProductSupplierMappings { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    public virtual DbSet<Return> Returns { get; set; }

    public virtual DbSet<ReturnInspection> ReturnInspections { get; set; }

    public virtual DbSet<ReturnItem> ReturnItems { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<ShipmentItem> ShipmentItems { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<StorageType> StorageTypes { get; set; }

    public virtual DbSet<StoreDemandLimit> StoreDemandLimits { get; set; }

    public virtual DbSet<StoreOrder> StoreOrders { get; set; }

    public virtual DbSet<StoreOrderItem> StoreOrderItems { get; set; }

    public virtual DbSet<StoreProfile> StoreProfiles { get; set; }

    public virtual DbSet<Subcategory> Subcategories { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierProductRate> SupplierProductRates { get; set; }

    public virtual DbSet<SupplierType> SupplierTypes { get; set; }

    public virtual DbSet<TaxCategory> TaxCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ASHRUTHA\\SQLEXPRESS;Database=Manufacturing_Logistics_DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressIdPk).HasName("PK__Address__BAB0CB88AE34C3D1");

            entity.ToTable("Address");

            entity.Property(e => e.AddressIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Address_ID_Pk");
            entity.Property(e => e.AddressLine1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Address_Line1");
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Address_Line2");
            entity.Property(e => e.CityIdFk).HasColumnName("City_ID_Fk");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.Pincode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CityIdFkNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityIdFk)
                .HasConstraintName("FK_Address_City");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.AddressCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Address_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.AddressUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Address_Updated");
        });

        modelBuilder.Entity<Carrier>(entity =>
        {
            entity.HasKey(e => e.CarrierIdPk).HasName("PK__Carriers__44DFB97BEFE9E745");

            entity.Property(e => e.CarrierIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Carrier_Id_PK");
            entity.Property(e => e.CarrierName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Carrier_Name");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.CarrierCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Carrier_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.CarrierUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Carrier_Updated");
        });

        modelBuilder.Entity<Catalog>(entity =>
        {
            entity.HasKey(e => e.CatalogIdPk).HasName("PK__Catalog__F677A35D411912FB");

            entity.ToTable("Catalog");

            entity.Property(e => e.CatalogIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Catalog_Id_Pk");
            entity.Property(e => e.CatalogKey)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Catalog_Key");
            entity.Property(e => e.CatalogType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Catalog_Type");
            entity.Property(e => e.CatalogValue)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Catalog_Value");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.CatalogCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Catalog_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.CatalogUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Catalog_Updated");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryIdPk).HasName("PK__Category__33B495924F3231D6");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Category_ID_Pk");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Category_Name");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.CategoryCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Category_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.CategoryUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Category_Updated");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityIdPk).HasName("PK__City__19B7D06C425C802E");

            entity.ToTable("City");

            entity.Property(e => e.CityIdPk)
                .ValueGeneratedNever()
                .HasColumnName("City_ID_Pk");
            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("City_Name");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.StateIdFk).HasColumnName("State_ID_Fk");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.CityCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_City_Created");

            entity.HasOne(d => d.StateIdFkNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateIdFk)
                .HasConstraintName("FK_City_State");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.CityUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_City_Updated");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryIdPk).HasName("PK__Country__C37754FAE7ECE7AC");

            entity.ToTable("Country");

            entity.Property(e => e.CountryIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Country_ID_Pk");
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Country_Name");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.CountryCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Country_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.CountryUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Country_Updated");
        });

        modelBuilder.Entity<Dc>(entity =>
        {
            entity.HasKey(e => e.DcIdPk).HasName("PK__DC__62E450AE05F672F3");

            entity.ToTable("DC");

            entity.Property(e => e.DcIdPk)
                .ValueGeneratedNever()
                .HasColumnName("DC_Id_Pk");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.DcAddressIdFk).HasColumnName("DC_Address_Id_Fk");
            entity.Property(e => e.DcName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DC_Name");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.DcCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_DC_Created");

            entity.HasOne(d => d.DcAddressIdFkNavigation).WithMany(p => p.Dcs)
                .HasForeignKey(d => d.DcAddressIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DC_Address");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.DcUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_DC_Updated");
        });

        modelBuilder.Entity<DcInventory>(entity =>
        {
            entity.HasKey(e => e.DcInventoryIdPk).HasName("PK__DC_Inven__00F5CE9AF22B7598");

            entity.ToTable("DC_Inventory");

            entity.Property(e => e.DcInventoryIdPk)
                .ValueGeneratedNever()
                .HasColumnName("DC_Inventory_Id_Pk");
            entity.Property(e => e.AvailableQuantity).HasColumnName("Available_Quantity");
            entity.Property(e => e.BlockedQuantity).HasColumnName("Blocked_Quantity");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.DamagedQuantity).HasColumnName("Damaged_Quantity");
            entity.Property(e => e.DcIdFk).HasColumnName("DC_Id_Fk");
            entity.Property(e => e.IntransitQuantity).HasColumnName("Intransit_Quantity");
            entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_Fk");
            entity.Property(e => e.ReservedQuantity).HasColumnName("Reserved_Quantity");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.DcInventoryCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_DCI_Created");

            entity.HasOne(d => d.DcIdFkNavigation).WithMany(p => p.DcInventories)
                .HasForeignKey(d => d.DcIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DCI_DC");

            entity.HasOne(d => d.ProductIdFkNavigation).WithMany(p => p.DcInventories)
                .HasForeignKey(d => d.ProductIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DCI_Product");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.DcInventoryUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_DCI_Updated");
        });

        modelBuilder.Entity<DcReceiving>(entity =>
        {
            entity.HasKey(e => e.DcReceivingIdPk).HasName("PK__DC_Recei__689FD3F071D1A555");

            entity.ToTable("DC_Receiving");

            entity.Property(e => e.DcReceivingIdPk)
                .ValueGeneratedNever()
                .HasColumnName("DC_Receiving_Id_Pk");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.DcIdFk).HasColumnName("DC_Id_Fk");
            entity.Property(e => e.ReceivingStatusIdFk).HasColumnName("Receiving_Status_Id_Fk");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ShipmentIdFk).HasColumnName("Shipment_Id_Fk");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.DcReceivingCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_DCR_Created");

            entity.HasOne(d => d.DcIdFkNavigation).WithMany(p => p.DcReceivings)
                .HasForeignKey(d => d.DcIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DCR_DC");

            entity.HasOne(d => d.ReceivingStatusIdFkNavigation).WithMany(p => p.DcReceivings)
                .HasForeignKey(d => d.ReceivingStatusIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DCR_Status");

            entity.HasOne(d => d.ShipmentIdFkNavigation).WithMany(p => p.DcReceivings)
                .HasForeignKey(d => d.ShipmentIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DCR_Shipment");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.DcReceivingUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_DCR_Updated");
        });

        modelBuilder.Entity<DcReceivingItem>(entity =>
        {
            entity.HasKey(e => e.DcReceivingItemsIdPk).HasName("PK__DC_Recei__7269178EBBF4FE32");

            entity.ToTable("DC_Receiving_Items");

            entity.Property(e => e.DcReceivingItemsIdPk)
                .ValueGeneratedNever()
                .HasColumnName("DC_Receiving_Items_Id_Pk");
            entity.Property(e => e.AcceptedQuantity).HasColumnName("Accepted_Quantity");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.DamagedQuantity).HasColumnName("Damaged_Quantity");
            entity.Property(e => e.DcReceivingIdFk).HasColumnName("DC_Receiving_Id_Fk");
            entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_Fk");
            entity.Property(e => e.ReceivedQuantity).HasColumnName("Received_Quantity");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.DcReceivingItemCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_DCRI_Created");

            entity.HasOne(d => d.DcReceivingIdFkNavigation).WithMany(p => p.DcReceivingItems)
                .HasForeignKey(d => d.DcReceivingIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DCRI_Receiving");

            entity.HasOne(d => d.ProductIdFkNavigation).WithMany(p => p.DcReceivingItems)
                .HasForeignKey(d => d.ProductIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DCRI_Product");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.DcReceivingItemUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_DCRI_Updated");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryIdPk).HasName("PK__Delivery__51FCD93E62A589E5");

            entity.ToTable("Delivery");

            entity.Property(e => e.DeliveryIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Delivery_Id_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.DeliveryDate).HasColumnName("Delivery_Date");
            entity.Property(e => e.DeliveryStatusIdFk).HasColumnName("Delivery_Status_Id_FK");
            entity.Property(e => e.DispatchIdFk).HasColumnName("Dispatch_Id_FK");
            entity.Property(e => e.ReceivedByManagersIdFk).HasColumnName("Received_By_Managers_Id_FK");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.DeliveryCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Delivery_Created");

            entity.HasOne(d => d.DeliveryStatusIdFkNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.DeliveryStatusIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Delivery_Status");

            entity.HasOne(d => d.DispatchIdFkNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.DispatchIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Delivery_Dispatch");

            entity.HasOne(d => d.ReceivedByManagersIdFkNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.ReceivedByManagersIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Delivery_Manager");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.DeliveryUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Delivery_Updated");
        });

        modelBuilder.Entity<Dispatch>(entity =>
        {
            entity.HasKey(e => e.DispatchIdPk).HasName("PK__Dispatch__1C7BAFE2FDD7D527");

            entity.ToTable("Dispatch");

            entity.Property(e => e.DispatchIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Dispatch_Id_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.DcIdFk).HasColumnName("Dc_Id_FK");
            entity.Property(e => e.DispatchDate).HasColumnName("Dispatch_Date");
            entity.Property(e => e.DispatchStatusIdFk).HasColumnName("Dispatch_Status_Id_FK");
            entity.Property(e => e.StoreIdFk).HasColumnName("Store_Id_FK");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.DispatchCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Dispatch_Created");

            entity.HasOne(d => d.DcIdFkNavigation).WithMany(p => p.Dispatches)
                .HasForeignKey(d => d.DcIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dispatch_DC");

            entity.HasOne(d => d.DispatchStatusIdFkNavigation).WithMany(p => p.Dispatches)
                .HasForeignKey(d => d.DispatchStatusIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dispatch_Status");

            entity.HasOne(d => d.StoreIdFkNavigation).WithMany(p => p.Dispatches)
                .HasForeignKey(d => d.StoreIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dispatch_Store");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.DispatchUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Dispatch_Updated");
        });

        modelBuilder.Entity<DispatchItem>(entity =>
        {
            entity.HasKey(e => e.DispatchItemIdPk).HasName("PK__Dispatch__737D80E480F6DEF0");

            entity.ToTable("Dispatch_Items");

            entity.Property(e => e.DispatchItemIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Dispatch_Item_Id_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.DispatchIdFk).HasColumnName("Dispatch_Id_FK");
            entity.Property(e => e.DispatchedQuantity).HasColumnName("Dispatched_Quantity");
            entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_FK");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.DispatchItemCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_DI_Created");

            entity.HasOne(d => d.DispatchIdFkNavigation).WithMany(p => p.DispatchItems)
                .HasForeignKey(d => d.DispatchIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DI_Dispatch");

            entity.HasOne(d => d.ProductIdFkNavigation).WithMany(p => p.DispatchItems)
                .HasForeignKey(d => d.ProductIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DI_Product");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.DispatchItemUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_DI_Updated");
        });

        modelBuilder.Entity<InventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.InventoryTransactionIdPk).HasName("PK__Inventor__16B8679892D79794");

            entity.ToTable("Inventory_Transactions");

            entity.Property(e => e.InventoryTransactionIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Inventory_Transaction_Id_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.DcIdFk).HasColumnName("Dc_Id_FK");
            entity.Property(e => e.InspectionIdFk).HasColumnName("Inspection_Id_FK");
            entity.Property(e => e.QuantityChange).HasColumnName("Quantity_Change");
            entity.Property(e => e.TransactionTypeIdFk).HasColumnName("Transaction_Type_Id_FK");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.InventoryTransactionCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_IT_Created");

            entity.HasOne(d => d.DcIdFkNavigation).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.DcIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IT_DC");

            entity.HasOne(d => d.InspectionIdFkNavigation).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.InspectionIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IT_Inspection");

            entity.HasOne(d => d.TransactionTypeIdFkNavigation).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.TransactionTypeIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IT_Type");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.InventoryTransactionUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_IT_Updated");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationIdPk).HasName("PK__Location__0A3A149BB9F00BF8");

            entity.ToTable("Location");

            entity.Property(e => e.LocationIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Location_Id_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Location_Name");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.LocationCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Location_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.LocationUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Location_Updated");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagersIdPk).HasName("PK__Managers__B14864019150705C");

            entity.Property(e => e.ManagersIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Managers_Id_Pk");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.ManagersContactCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Managers_Contact_Code");
            entity.Property(e => e.ManagersContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Managers_Contact_Phone");
            entity.Property(e => e.ManagersEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Managers__Email");
            entity.Property(e => e.ManagersName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Managers_Name");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.ManagerCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Manager_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.ManagerUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Manager_Updated");
        });

        modelBuilder.Entity<OrderPriority>(entity =>
        {
            entity.HasKey(e => e.OrderPriorityIdPk).HasName("PK__Order_Pr__9E7B0941849B7656");

            entity.ToTable("Order_Priority");

            entity.Property(e => e.OrderPriorityIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Order_Priority_Id_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.PriorityDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Priority_Description");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Priority_Name");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.OrderPriorityCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Priority_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.OrderPriorityUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Priority_Updated");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductIdPk).HasName("PK__Products__B8F830833498446B");

            entity.Property(e => e.ProductIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Product_ID_Pk");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.HsnCode).HasColumnName("HSN_Code");
            entity.Property(e => e.PackSize)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Pack_Size");
            entity.Property(e => e.ProductName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Product_Name");
            entity.Property(e => e.ProductStatusIdFk).HasColumnName("Product_Status_Id_Fk");
            entity.Property(e => e.ProductWeight)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Product_Weight");
            entity.Property(e => e.StorageTypeIdFk).HasColumnName("Storage_Type_Id_Fk");
            entity.Property(e => e.SubcategoryIdFk).HasColumnName("Subcategory_ID_Fk");
            entity.Property(e => e.TaxCategoryIdFk).HasColumnName("Tax_Category_Id_Fk");
            entity.Property(e => e.UnitOfMeasurementIdFk).HasColumnName("Unit_Of_Measurement_Id_Fk");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.ProductCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Product_Created");

            entity.HasOne(d => d.StorageTypeIdFkNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.StorageTypeIdFk)
                .HasConstraintName("FK_Products_Storage");

            entity.HasOne(d => d.SubcategoryIdFkNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubcategoryIdFk)
                .HasConstraintName("FK_Products_Subcategory");

            entity.HasOne(d => d.TaxCategoryIdFkNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.TaxCategoryIdFk)
                .HasConstraintName("FK_Products_Tax");

            entity.HasOne(d => d.UnitOfMeasurementIdFkNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.UnitOfMeasurementIdFk)
                .HasConstraintName("FK_Products_UOM");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.ProductUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Product_Updated");
        });

        modelBuilder.Entity<ProductStoreMapping>(entity =>
        {
            entity.HasKey(e => e.ProductStoreIdPk).HasName("PK__Product___81F28CBC27682B7A");

            entity.ToTable("Product_Store_Mapping");

            entity.Property(e => e.ProductStoreIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Product_Store_ID_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.MaxQuantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Max_Quantity");
            entity.Property(e => e.MinQuantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Min_Quantity");
            entity.Property(e => e.ProductIdFk).HasColumnName("Product_ID_Fk");
            entity.Property(e => e.ProductStoreStatusIdFk).HasColumnName("Product_Store_Status_Id_Fk");
            entity.Property(e => e.ReorderPoint)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Reorder_Point");
            entity.Property(e => e.StoreIdFk).HasColumnName("Store_ID_Fk");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.ProductStoreMappingCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_PSM2_Created");

            entity.HasOne(d => d.ProductIdFkNavigation).WithMany(p => p.ProductStoreMappings)
                .HasForeignKey(d => d.ProductIdFk)
                .HasConstraintName("FK_PSM2_Product");

            entity.HasOne(d => d.ProductStoreStatusIdFkNavigation).WithMany(p => p.ProductStoreMappings)
                .HasForeignKey(d => d.ProductStoreStatusIdFk)
                .HasConstraintName("FK_PSM2_Status");

            entity.HasOne(d => d.StoreIdFkNavigation).WithMany(p => p.ProductStoreMappings)
                .HasForeignKey(d => d.StoreIdFk)
                .HasConstraintName("FK_PSM2_Store");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.ProductStoreMappingUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_PSM2_Updated");
        });

        modelBuilder.Entity<ProductSupplierMapping>(entity =>
        {
            entity.HasKey(e => e.ProductSupplierIdPk).HasName("PK__Product___94BB7377D01D6A54");

            entity.ToTable("Product_Supplier_Mapping");

            entity.Property(e => e.ProductSupplierIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Product_Supplier_ID_Pk");
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
            entity.Property(e => e.LeadTime)
                .HasColumnType("datetime")
                .HasColumnName("Lead_Time");
            entity.Property(e => e.ProductIdFk).HasColumnName("Product_ID_Fk");
            entity.Property(e => e.ProductSupplierStatusIdFk).HasColumnName("Product_Supplier_Status_Id_Fk");
            entity.Property(e => e.SupplierIdFk).HasColumnName("Supplier_ID_FK");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.ProductSupplierMappingCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_PSM_Created");

            entity.HasOne(d => d.ProductIdFkNavigation).WithMany(p => p.ProductSupplierMappings)
                .HasForeignKey(d => d.ProductIdFk)
                .HasConstraintName("FK_PSM_Product");

            entity.HasOne(d => d.ProductSupplierStatusIdFkNavigation).WithMany(p => p.ProductSupplierMappings)
                .HasForeignKey(d => d.ProductSupplierStatusIdFk)
                .HasConstraintName("FK_PSM_Status");

            entity.HasOne(d => d.SupplierIdFkNavigation).WithMany(p => p.ProductSupplierMappings)
                .HasForeignKey(d => d.SupplierIdFk)
                .HasConstraintName("FK_PSM_Supplier");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.ProductSupplierMappingUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_PSM_Updated");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderIdPk).HasName("PK__Purchase__E4716E7ABA449338");

            entity.ToTable("Purchase_Orders");

            entity.Property(e => e.PurchaseOrderIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Purchase_Order_Id_PK");
            entity.Property(e => e.ApprovedByUserIdFk).HasColumnName("Approved_By_User_Id_FK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.CurrencyIdFk).HasColumnName("Currency_Id_FK");
            entity.Property(e => e.ExpectedDeliveryDate).HasColumnName("Expected_Delivery_Date");
            entity.Property(e => e.OrderStatusIdFk).HasColumnName("Order_Status_Id_FK");
            entity.Property(e => e.PoDate).HasColumnName("PO_Date");
            entity.Property(e => e.SupplierIdFk).HasColumnName("Supplier_Id_FK");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.ApprovedByUserIdFkNavigation).WithMany(p => p.PurchaseOrderApprovedByUserIdFkNavigations)
                .HasForeignKey(d => d.ApprovedByUserIdFk)
                .HasConstraintName("FK_PO_Approved_User");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.PurchaseOrderCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_PO_Created");

            entity.HasOne(d => d.CurrencyIdFkNavigation).WithMany(p => p.PurchaseOrderCurrencyIdFkNavigations)
                .HasForeignKey(d => d.CurrencyIdFk)
                .HasConstraintName("FK_PO_Currency");

            entity.HasOne(d => d.OrderStatusIdFkNavigation).WithMany(p => p.PurchaseOrderOrderStatusIdFkNavigations)
                .HasForeignKey(d => d.OrderStatusIdFk)
                .HasConstraintName("FK_PO_Status");

            entity.HasOne(d => d.SupplierIdFkNavigation).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierIdFk)
                .HasConstraintName("FK_PO_Supplier");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.PurchaseOrderUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_PO_Updated");
        });

        modelBuilder.Entity<PurchaseOrderItem>(entity =>
        {
            entity.HasKey(e => e.PoItemIdPk).HasName("PK__Purchase__3F88059D67E21BBD");

            entity.ToTable("Purchase_Order_Items");

            entity.Property(e => e.PoItemIdPk)
                .ValueGeneratedNever()
                .HasColumnName("PO_Item_Id_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_FK");
            entity.Property(e => e.PurchaseOrderIdFk).HasColumnName("Purchase_Order_Id_FK");
            entity.Property(e => e.PurchaseQuantity).HasColumnName("Purchase_Quantity");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Unit_Price");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.PurchaseOrderItemCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_POI_Created");

            entity.HasOne(d => d.ProductIdFkNavigation).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.ProductIdFk)
                .HasConstraintName("FK_POI_Product");

            entity.HasOne(d => d.PurchaseOrderIdFkNavigation).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.PurchaseOrderIdFk)
                .HasConstraintName("FK_POI_PO");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.PurchaseOrderItemUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_POI_Updated");
        });

        modelBuilder.Entity<Return>(entity =>
        {
            entity.HasKey(e => e.ReturnIdPk).HasName("PK__Return__6665260C809E2D9D");

            entity.ToTable("Return");

            entity.HasIndex(e => e.ReturnRequestNumber, "UQ__Return__995114A97BEA10DC").IsUnique();

            entity.Property(e => e.ReturnIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Return_Id_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.DcIdFk).HasColumnName("Dc_Id_FK");
            entity.Property(e => e.ReturnDate).HasColumnName("Return_Date");
            entity.Property(e => e.ReturnRequestNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Return_Request_Number");
            entity.Property(e => e.ReturnStatusIdFk).HasColumnName("Return_Status_Id_FK");
            entity.Property(e => e.StoreIdFk).HasColumnName("Store_Id_FK");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.ReturnCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Return_Created");

            entity.HasOne(d => d.DcIdFkNavigation).WithMany(p => p.Returns)
                .HasForeignKey(d => d.DcIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Return_DC");

            entity.HasOne(d => d.ReturnStatusIdFkNavigation).WithMany(p => p.Returns)
                .HasForeignKey(d => d.ReturnStatusIdFk)
                .HasConstraintName("FK_Return_Status");

            entity.HasOne(d => d.StoreIdFkNavigation).WithMany(p => p.Returns)
                .HasForeignKey(d => d.StoreIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Return_Store");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.ReturnUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Return_Updated");
        });

        modelBuilder.Entity<ReturnInspection>(entity =>
        {
            entity.HasKey(e => e.InspectionIdPk).HasName("PK__Return_I__1A776A59F4009D53");

            entity.ToTable("Return_Inspection");

            entity.Property(e => e.InspectionIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Inspection_Id_PK");
            entity.Property(e => e.AcceptedQuantity).HasColumnName("Accepted_Quantity");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.DamagedQuantity).HasColumnName("Damaged_Quantity");
            entity.Property(e => e.InspectedQuantity).HasColumnName("Inspected_Quantity");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReturnIdFk).HasColumnName("Return_Id_FK");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.ReturnInspectionCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Inspection_Created");

            entity.HasOne(d => d.ReturnIdFkNavigation).WithMany(p => p.ReturnInspections)
                .HasForeignKey(d => d.ReturnIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inspection_Return");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.ReturnInspectionUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Inspection_Updated");
        });

        modelBuilder.Entity<ReturnItem>(entity =>
        {
            entity.HasKey(e => e.ReturnItemIdPk).HasName("PK__Return_I__134F4025C29A44A3");

            entity.ToTable("Return_Items");

            entity.Property(e => e.ReturnItemIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Return_Item_Id_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_FK");
            entity.Property(e => e.ReturnIdFk).HasColumnName("Return_Id_FK");
            entity.Property(e => e.ReturnReason)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Return_Reason");
            entity.Property(e => e.ReturnedQuantity).HasColumnName("Returned_Quantity");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.ReturnItemCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_RI_Created");

            entity.HasOne(d => d.ProductIdFkNavigation).WithMany(p => p.ReturnItems)
                .HasForeignKey(d => d.ProductIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RI_Product");

            entity.HasOne(d => d.ReturnIdFkNavigation).WithMany(p => p.ReturnItems)
                .HasForeignKey(d => d.ReturnIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RI_Return");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.ReturnItemUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_RI_Updated");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleIdPk).HasName("PK__Role__A58B54423A787793");

            entity.ToTable("Role");

            entity.Property(e => e.RoleIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Role_Id_Pk");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Role_Name");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.RoleCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Role_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.RoleUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Role_Updated");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.ShipmentIdPk).HasName("PK__Shipment__E3B1039397977852");

            entity.Property(e => e.ShipmentIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Shipment_Id_PK");
            entity.Property(e => e.ActualArrival).HasColumnName("Actual_Arrival");
            entity.Property(e => e.CarrierIdFk).HasColumnName("Carrier_Id_FK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.CurrentLocationIdFk).HasColumnName("Current_Location_Id_FK");
            entity.Property(e => e.DispatchDate).HasColumnName("Dispatch_Date");
            entity.Property(e => e.EstimatedArrival).HasColumnName("Estimated_Arrival");
            entity.Property(e => e.OriginLocationIdFk).HasColumnName("Origin_Location_Id_FK");
            entity.Property(e => e.PurchaseOrderIdFk).HasColumnName("Purchase_Order_Id_FK");
            entity.Property(e => e.ShipmentStatusIdFk).HasColumnName("Shipment_Status_Id_FK");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Tracking_Number");
            entity.Property(e => e.TransportModeIdFk).HasColumnName("Transport_Mode_Id_FK");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CarrierIdFkNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.CarrierIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_Carrier");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.ShipmentCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Shipment_Created");

            entity.HasOne(d => d.CurrentLocationIdFkNavigation).WithMany(p => p.ShipmentCurrentLocationIdFkNavigations)
                .HasForeignKey(d => d.CurrentLocationIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_Current_Location");

            entity.HasOne(d => d.OriginLocationIdFkNavigation).WithMany(p => p.ShipmentOriginLocationIdFkNavigations)
                .HasForeignKey(d => d.OriginLocationIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_Origin_Location");

            entity.HasOne(d => d.PurchaseOrderIdFkNavigation).WithMany(p => p.Shipments)
                .HasForeignKey(d => d.PurchaseOrderIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_PO");

            entity.HasOne(d => d.ShipmentStatusIdFkNavigation).WithMany(p => p.ShipmentShipmentStatusIdFkNavigations)
                .HasForeignKey(d => d.ShipmentStatusIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_Status");

            entity.HasOne(d => d.TransportModeIdFkNavigation).WithMany(p => p.ShipmentTransportModeIdFkNavigations)
                .HasForeignKey(d => d.TransportModeIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipment_Mode");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.ShipmentUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Shipment_Updated");
        });

        modelBuilder.Entity<ShipmentItem>(entity =>
        {
            entity.HasKey(e => e.ShipmentItemIdPk).HasName("PK__Shipment__A8A70398DA19D725");

            entity.ToTable("Shipment_Items");

            entity.Property(e => e.ShipmentItemIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Shipment_Item_Id_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.PoItemIdFk).HasColumnName("PO_Item_Id_FK");
            entity.Property(e => e.ShipmentIdFk).HasColumnName("Shipment_Id_FK");
            entity.Property(e => e.ShippedQuantity).HasColumnName("Shipped_Quantity");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.ShipmentItemCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_SI_Created");

            entity.HasOne(d => d.PoItemIdFkNavigation).WithMany(p => p.ShipmentItems)
                .HasForeignKey(d => d.PoItemIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SI_POItem");

            entity.HasOne(d => d.ShipmentIdFkNavigation).WithMany(p => p.ShipmentItems)
                .HasForeignKey(d => d.ShipmentIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SI_Shipment");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.ShipmentItemUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_SI_Updated");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateIdPk).HasName("PK__State__B5340874BD7FF3BA");

            entity.ToTable("State");

            entity.Property(e => e.StateIdPk)
                .ValueGeneratedNever()
                .HasColumnName("State_ID_Pk");
            entity.Property(e => e.CountryIdFk).HasColumnName("Country_ID_Fk");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.StateName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("State_Name");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CountryIdFkNavigation).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryIdFk)
                .HasConstraintName("FK_State_Country");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.StateCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_State_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.StateUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_State_Updated");
        });

        modelBuilder.Entity<StorageType>(entity =>
        {
            entity.HasKey(e => e.StorageTypeIdPk).HasName("PK__Storage___4D609B38D1C8F4CD");

            entity.ToTable("Storage_Type");

            entity.Property(e => e.StorageTypeIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Storage_Type_ID_Pk");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.StorageTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Storage_Type_Name");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.StorageTypeCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Storage_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.StorageTypeUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Storage_Updated");
        });

        modelBuilder.Entity<StoreDemandLimit>(entity =>
        {
            entity.HasKey(e => e.LimitIdPk).HasName("PK__Store_De__E8E61A918AE6E6E2");

            entity.ToTable("Store_Demand_Limits");

            entity.Property(e => e.LimitIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Limit_Id_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.EffectiveFromDate).HasColumnName("Effective_From_Date");
            entity.Property(e => e.EffectiveToDate).HasColumnName("Effective_To_Date");
            entity.Property(e => e.MaxOrderLevel).HasColumnName("Max_Order_Level");
            entity.Property(e => e.MinOrderLevel).HasColumnName("Min_Order_Level");
            entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_FK");
            entity.Property(e => e.StoreIdFk).HasColumnName("Store_Id_FK");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.StoreDemandLimitCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_SDL_Created");

            entity.HasOne(d => d.ProductIdFkNavigation).WithMany(p => p.StoreDemandLimits)
                .HasForeignKey(d => d.ProductIdFk)
                .HasConstraintName("FK_SDL_Product");

            entity.HasOne(d => d.StoreIdFkNavigation).WithMany(p => p.StoreDemandLimits)
                .HasForeignKey(d => d.StoreIdFk)
                .HasConstraintName("FK_SDL_Store");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.StoreDemandLimitUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_SDL_Updated");
        });

        modelBuilder.Entity<StoreOrder>(entity =>
        {
            entity.HasKey(e => e.StoreOrdersIdPk).HasName("PK__Store_Or__03124E8E0A35CA9A");

            entity.ToTable("Store_Orders");

            entity.Property(e => e.StoreOrdersIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Store_Orders_Id_PK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.ExpectedDeliveryDate).HasColumnName("Expected_Delivery_Date");
            entity.Property(e => e.OrderPriorityIdFk).HasColumnName("Order_Priority_Id_FK");
            entity.Property(e => e.OrderStatusIdFk).HasColumnName("Order_Status_Id_FK");
            entity.Property(e => e.RequestedDeliveryDate).HasColumnName("Requested_Delivery_Date");
            entity.Property(e => e.StoreIdFk).HasColumnName("Store_Id_FK");
            entity.Property(e => e.TotalOrderValue)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Total_Order_Value");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.StoreOrderCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_TO_Created");

            entity.HasOne(d => d.OrderPriorityIdFkNavigation).WithMany(p => p.StoreOrders)
                .HasForeignKey(d => d.OrderPriorityIdFk)
                .HasConstraintName("FK_TO_Priority");

            entity.HasOne(d => d.OrderStatusIdFkNavigation).WithMany(p => p.StoreOrders)
                .HasForeignKey(d => d.OrderStatusIdFk)
                .HasConstraintName("FK_TO_Status");

            entity.HasOne(d => d.StoreIdFkNavigation).WithMany(p => p.StoreOrders)
                .HasForeignKey(d => d.StoreIdFk)
                .HasConstraintName("FK_TO_Store");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.StoreOrderUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_TO_Updated");
        });

        modelBuilder.Entity<StoreOrderItem>(entity =>
        {
            entity.HasKey(e => e.StoreOrderItemsIdPk).HasName("PK__Store_Or__5119C316355BFB2B");

            entity.ToTable("Store_Order_Items");

            entity.Property(e => e.StoreOrderItemsIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Store_Order_Items_Id_PK");
            entity.Property(e => e.AllocatedQuantity).HasColumnName("Allocated_Quantity");
            entity.Property(e => e.AllocationNotes)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Allocation_Notes");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_FK");
            entity.Property(e => e.RequestedQuantity).HasColumnName("Requested_Quantity");
            entity.Property(e => e.StoreOrdersIdFk).HasColumnName("Store_Orders_Id_FK");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.StoreOrderItemCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_TOI_Created");

            entity.HasOne(d => d.ProductIdFkNavigation).WithMany(p => p.StoreOrderItems)
                .HasForeignKey(d => d.ProductIdFk)
                .HasConstraintName("FK_TOI_Product");

            entity.HasOne(d => d.StoreOrdersIdFkNavigation).WithMany(p => p.StoreOrderItems)
                .HasForeignKey(d => d.StoreOrdersIdFk)
                .HasConstraintName("FK_TOI_Order");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.StoreOrderItemUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_TOI_Updated");
        });

        modelBuilder.Entity<StoreProfile>(entity =>
        {
            entity.HasKey(e => e.StoreIdPk).HasName("PK__Store_Pr__ED23CFDCAD8C78A9");

            entity.ToTable("Store_Profiles");

            entity.Property(e => e.StoreIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Store_Id_PK");
            entity.Property(e => e.AddressIdFk).HasColumnName("Address_Id_FK");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.ManagersIdFk).HasColumnName("Managers_Id_Fk");
            entity.Property(e => e.StoreName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Store_Name");
            entity.Property(e => e.StoreStatusIdFk).HasColumnName("Store_Status_Id_FK");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.AddressIdFkNavigation).WithMany(p => p.StoreProfiles)
                .HasForeignKey(d => d.AddressIdFk)
                .HasConstraintName("FK_Store_Address");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.StoreProfileCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Store_Created");

            entity.HasOne(d => d.ManagersIdFkNavigation).WithMany(p => p.StoreProfiles)
                .HasForeignKey(d => d.ManagersIdFk)
                .HasConstraintName("FK_Store_Manager");

            entity.HasOne(d => d.StoreStatusIdFkNavigation).WithMany(p => p.StoreProfiles)
                .HasForeignKey(d => d.StoreStatusIdFk)
                .HasConstraintName("FK_Store_Status");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.StoreProfileUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Store_Updated");
        });

        modelBuilder.Entity<Subcategory>(entity =>
        {
            entity.HasKey(e => e.SubcategoryIdPk).HasName("PK__Subcateg__7765F25A85EB4054");

            entity.ToTable("Subcategory");

            entity.Property(e => e.SubcategoryIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Subcategory_ID_Pk");
            entity.Property(e => e.CategoryIdFk).HasColumnName("Category_ID_Fk");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.SubcategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Subcategory_Name");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CategoryIdFkNavigation).WithMany(p => p.Subcategories)
                .HasForeignKey(d => d.CategoryIdFk)
                .HasConstraintName("FK_Subcategory_Category");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.SubcategoryCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Subcategory_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.SubcategoryUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Subcategory_Updated");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierIdPk).HasName("PK__Supplier__24CBC76D6ABD97E5");

            entity.Property(e => e.SupplierIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Supplier_ID_Pk");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.CurrencyIdFk).HasColumnName("Currency_Id_Fk");
            entity.Property(e => e.GstNumber).HasColumnName("GST_Number");
            entity.Property(e => e.ManagersIdFk).HasColumnName("Managers_Id_Fk");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Supplier_Name");
            entity.Property(e => e.SupplierStatusIdFk).HasColumnName("Supplier_Status_Id_Fk");
            entity.Property(e => e.SupplierTypeIdFk).HasColumnName("Supplier_Type_Id_Fk");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.SupplierCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Supplier_Created");

            entity.HasOne(d => d.CurrencyIdFkNavigation).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CurrencyIdFk)
                .HasConstraintName("FK_Suppliers_Currency");

            entity.HasOne(d => d.ManagersIdFkNavigation).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.ManagersIdFk)
                .HasConstraintName("FK_Suppliers_Manager");

            entity.HasOne(d => d.SupplierTypeIdFkNavigation).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.SupplierTypeIdFk)
                .HasConstraintName("FK_Suppliers_Type");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.SupplierUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Supplier_Updated");
        });

        modelBuilder.Entity<SupplierProductRate>(entity =>
        {
            entity.HasKey(e => e.SupplierProductRateIdPk).HasName("PK__Supplier__E9B547A234C0A419");

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
            entity.Property(e => e.ProductIdFk).HasColumnName("Product_ID_Fk");
            entity.Property(e => e.SupplierIdFk).HasColumnName("Supplier_ID_Fk");
            entity.Property(e => e.SupplyingQuantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Supplying_Quantity");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.SupplierProductRateCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_SPR_Created");

            entity.HasOne(d => d.ProductIdFkNavigation).WithMany(p => p.SupplierProductRates)
                .HasForeignKey(d => d.ProductIdFk)
                .HasConstraintName("FK_SPR_Product");

            entity.HasOne(d => d.SupplierIdFkNavigation).WithMany(p => p.SupplierProductRates)
                .HasForeignKey(d => d.SupplierIdFk)
                .HasConstraintName("FK_SPR_Supplier");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.SupplierProductRateUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_SPR_Updated");
        });

        modelBuilder.Entity<SupplierType>(entity =>
        {
            entity.HasKey(e => e.SupplierTypeIdPk).HasName("PK__Supplier__02B3DBE748096809");

            entity.ToTable("Supplier_Type");

            entity.Property(e => e.SupplierTypeIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Supplier_Type_ID_Pk");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.SupplierTypeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Supplier_Type_Name");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.SupplierTypeCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_SupplierType_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.SupplierTypeUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_SupplierType_Updated");
        });

        modelBuilder.Entity<TaxCategory>(entity =>
        {
            entity.HasKey(e => e.TaxCategoryIdPk).HasName("PK__Tax_Cate__99F7CD732D8797DF");

            entity.ToTable("Tax_Category");

            entity.Property(e => e.TaxCategoryIdPk)
                .ValueGeneratedNever()
                .HasColumnName("Tax_Category_ID_Pk");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.TaxCategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Tax_Category_name");
            entity.Property(e => e.TaxCategoryValue).HasColumnName("Tax_Category_Value");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.TaxCategoryCreatedByUserIdFkNavigations)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Tax_Created");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.TaxCategoryUpdatedByUserIdFkNavigations)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Tax_Updated");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserIdPk).HasName("PK__Users__4AB5226DB96C49F5");

            entity.Property(e => e.UserIdPk)
                .ValueGeneratedNever()
                .HasColumnName("User_ID_Pk");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Contact_Number");
            entity.Property(e => e.CreatedByUserIdFk).HasColumnName("Created_By_User_Id_Fk");
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Created_DateTime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleIdFk).HasColumnName("Role_Id_Fk");
            entity.Property(e => e.UpdatedByUserIdFk).HasColumnName("Updated_By_User_Id_Fk");
            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_DateTime");
            entity.Property(e => e.UserAddressIdFk).HasColumnName("User_Address_Id_FK");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("User_Name");

            entity.HasOne(d => d.CreatedByUserIdFkNavigation).WithMany(p => p.InverseCreatedByUserIdFkNavigation)
                .HasForeignKey(d => d.CreatedByUserIdFk)
                .HasConstraintName("FK_Users_Created");

            entity.HasOne(d => d.RoleIdFkNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleIdFk)
                .HasConstraintName("FK_Users_Role");

            entity.HasOne(d => d.UpdatedByUserIdFkNavigation).WithMany(p => p.InverseUpdatedByUserIdFkNavigation)
                .HasForeignKey(d => d.UpdatedByUserIdFk)
                .HasConstraintName("FK_Users_Updated");

            entity.HasOne(d => d.UserAddressIdFkNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserAddressIdFk)
                .HasConstraintName("FK_Users_Address");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
