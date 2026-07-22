using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Manufacturing_Logisitcs_Ripples_Training_Api.Models;

public partial class ManufacturingLogisticsProjectDbContext : DbContext
{
    public ManufacturingLogisticsProjectDbContext()
    {
    }

    public ManufacturingLogisticsProjectDbContext(DbContextOptions<ManufacturingLogisticsProjectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    public virtual DbSet<SupplierProductRate> SupplierProductRates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1HBKGLM\\SQLEXPRESS01;Database=Manufacturing_Logistics_Project_DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
        });

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
