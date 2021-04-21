using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class SalesOrderDetailConfiguration : IEntityTypeConfiguration<SalesOrderDetail>
    {
        public void Configure(EntityTypeBuilder<SalesOrderDetail> builder)
        {
            // Name and Schema
            builder.ToTable("SalesOrderDetail", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.SalesOrderID, e.SalesOrderDetailID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.SalesOrderID)
            .HasColumnType("int");

            builder.Property(p => p.SalesOrderDetailID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.CarrierTrackingNumber)
            .HasColumnType("nvarchar(25)");

            builder.Property(p => p.OrderQty)
            .HasColumnType("smallint");

            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.SpecialOfferID)
            .HasColumnType("int");

            builder.Property(p => p.UnitPrice)
            .HasColumnType("money");

            builder.Property(p => p.UnitPriceDiscount)
            .HasColumnType("money")
            .HasDefaultValue("((0.0))");

            builder.Property(p => p.LineTotal)
            .HasColumnType("numeric")
            .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", false);

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValue("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValue("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_SalesOrderDetail_rowguid");

            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("IX_SalesOrderDetail_ProductID");

            builder.HasIndex(e => new { e.SalesOrderID })
            .HasDatabaseName("FK_SalesOrderDetail_SalesOrderHeader_SalesOrderHeader");

            builder.HasIndex(e => new { e.ProductID, e.SpecialOfferID })
            .HasDatabaseName("FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferProduct");

            builder.HasOne(e => e.SalesOrderHeader)
            .WithMany(p => p.SalesOrderDetails)
            .HasForeignKey(e => new { e.SalesOrderID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_SalesOrderDetail_SalesOrderHeader_SalesOrderHeader_Constraint");

            builder.HasOne(e => e.SpecialOfferProduct)
            .WithMany(p => p.SalesOrderDetails)
            .HasForeignKey(e => new { e.ProductID, e.SpecialOfferID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferProduct_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}