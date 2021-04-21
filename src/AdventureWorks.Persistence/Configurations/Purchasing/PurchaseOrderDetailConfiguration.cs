using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Persistence.Configurations.Purchasing
{
    public partial class PurchaseOrderDetailConfiguration : IEntityTypeConfiguration<PurchaseOrderDetail>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder)
        {
            // Name and Schema
            builder.ToTable("PurchaseOrderDetail", "Purchasing");

            // Primary Key
            builder.HasKey(e => new { e.PurchaseOrderID, e.PurchaseOrderDetailID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.PurchaseOrderID)
            .HasColumnType("int");

            builder.Property(p => p.PurchaseOrderDetailID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.DueDate)
            .HasColumnType("datetime");

            builder.Property(p => p.OrderQty)
            .HasColumnType("smallint");

            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.UnitPrice)
            .HasColumnType("money");

            builder.Property(p => p.LineTotal)
            .HasColumnType("money")
            .HasComputedColumnSql("(isnull([OrderQty]*[UnitPrice],(0.00)))", false);

            builder.Property(p => p.ReceivedQty)
            .HasColumnType("decimal(8,2)");

            builder.Property(p => p.RejectedQty)
            .HasColumnType("decimal(8,2)");

            builder.Property(p => p.StockedQty)
            .HasColumnType("decimal(9,2)")
            .HasComputedColumnSql("(isnull([ReceivedQty]-[RejectedQty],(0.00)))", false);

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValue("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("IX_PurchaseOrderDetail_ProductID");

            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("FK_PurchaseOrderDetail_Product_Product");

            builder.HasIndex(e => new { e.PurchaseOrderID })
            .HasDatabaseName("FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderHeader");

            builder.HasOne(e => e.Product)
            .WithMany(p => p.PurchaseOrderDetails)
            .HasForeignKey(e => new { e.ProductID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_PurchaseOrderDetail_Product_Product_Constraint");

            builder.HasOne(e => e.PurchaseOrderHeader)
            .WithMany(p => p.PurchaseOrderDetails)
            .HasForeignKey(e => new { e.PurchaseOrderID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderHeader_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}