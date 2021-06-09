using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Persistence.Configurations.Purchasing
{
    public partial class ProductVendorConfiguration : IEntityTypeConfiguration<ProductVendor>
    {
        public void Configure(EntityTypeBuilder<ProductVendor> builder)
        {
            // Name and Schema
            builder.ToTable("ProductVendor", "Purchasing");

            // Primary Key
            builder.HasKey(e => new { e.ProductID, e.VendorID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.VendorID)
            .HasColumnType("int");

            builder.Property(p => p.AverageLeadTime)
            .HasColumnType("int");

            builder.Property(p => p.StandardPrice)
            .HasColumnType("money");

            builder.Property(p => p.LastReceiptCost)
            .HasColumnType("money");

            builder.Property(p => p.LastReceiptDate)
            .HasColumnType("datetime");

            builder.Property(p => p.MinOrderQty)
            .HasColumnType("int");

            builder.Property(p => p.MaxOrderQty)
            .HasColumnType("int");

            builder.Property(p => p.OnOrderQty)
            .HasColumnType("int");

            builder.Property(p => p.UnitMeasureCode)
            .HasColumnType("nchar(3)")
            .IsRequired();

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.UnitMeasureCode })
            .HasDatabaseName("IX_ProductVendor_UnitMeasureCode");

            builder.HasIndex(e => new { e.VendorID })
            .HasDatabaseName("IX_ProductVendor_VendorID");

            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("FK_ProductVendor_Product_Product");

            builder.HasIndex(e => new { e.UnitMeasureCode })
            .HasDatabaseName("FK_ProductVendor_UnitMeasure_UnitMeasure");

            builder.HasIndex(e => new { e.VendorID })
            .HasDatabaseName("FK_ProductVendor_Vendor_Vendor");

            builder.HasOne(e => e.Product)
            .WithMany(p => p.ProductVendors)
            .HasForeignKey(e => new { e.ProductID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ProductVendor_Product_Product_Constraint");

            builder.HasOne(e => e.UnitMeasure)
            .WithMany(p => p.ProductVendors)
            .HasForeignKey(e => new { e.UnitMeasureCode })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ProductVendor_UnitMeasure_UnitMeasure_Constraint");

            builder.HasOne(e => e.Vendor)
            .WithMany(p => p.ProductVendors)
            .HasForeignKey(e => new { e.VendorID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ProductVendor_Vendor_Vendor_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}