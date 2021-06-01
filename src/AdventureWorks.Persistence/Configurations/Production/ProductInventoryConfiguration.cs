using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class ProductInventoryConfiguration : IEntityTypeConfiguration<ProductInventory>
    {
        public void Configure(EntityTypeBuilder<ProductInventory> builder)
        {
            // Name and Schema
            builder.ToTable("ProductInventory", "Production");

            // Primary Key
            builder.HasKey(e => new { e.ProductID, e.LocationID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.LocationID)
            .HasColumnType("smallint");

            builder.Property(p => p.Shelf)
            .HasColumnType("nvarchar(10)")
            .IsRequired();

            builder.Property(p => p.Bin)
            .HasColumnType("tinyint");

            builder.Property(p => p.Quantity)
            .HasColumnType("smallint")
            .HasDefaultValueSql("((0))");

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys


            builder.HasIndex(e => new { e.LocationID })
            .HasDatabaseName("FK_ProductInventory_Location_Location");

            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("FK_ProductInventory_Product_Product");

            builder.HasOne(e => e.Location)
            .WithMany(p => p.ProductInventories)
            .HasForeignKey(e => new { e.LocationID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ProductInventory_Location_Location_Constraint");

            builder.HasOne(e => e.Product)
            .WithMany(p => p.ProductInventories)
            .HasForeignKey(e => new { e.ProductID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ProductInventory_Product_Product_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}