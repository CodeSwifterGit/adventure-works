using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Name and Schema
            builder.ToTable("Product", "Production");

            // Primary Key
            builder.HasKey(e => new { e.ProductID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ProductID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.ProductNumber)
            .HasColumnType("nvarchar(25)")
            .IsRequired();

            builder.Property(p => p.MakeFlag)
            .HasColumnType("bit")
            .HasDefaultValueSql("((1))");

            builder.Property(p => p.FinishedGoodsFlag)
            .HasColumnType("bit")
            .HasDefaultValueSql("((1))");

            builder.Property(p => p.Color)
            .HasColumnType("nvarchar(15)");

            builder.Property(p => p.SafetyStockLevel)
            .HasColumnType("smallint");

            builder.Property(p => p.ReorderPoint)
            .HasColumnType("smallint");

            builder.Property(p => p.StandardCost)
            .HasColumnType("money");

            builder.Property(p => p.ListPrice)
            .HasColumnType("money");

            builder.Property(p => p.Size)
            .HasColumnType("nvarchar(5)");

            builder.Property(p => p.SizeUnitMeasureCode)
            .HasColumnType("nchar(3)");

            builder.Property(p => p.WeightUnitMeasureCode)
            .HasColumnType("nchar(3)");

            builder.Property(p => p.Weight)
            .HasColumnType("decimal(8,2)");

            builder.Property(p => p.DaysToManufacture)
            .HasColumnType("int");

            builder.Property(p => p.ProductLine)
            .HasColumnType("nchar(2)");

            builder.Property(p => p.Class)
            .HasColumnType("nchar(2)");

            builder.Property(p => p.Style)
            .HasColumnType("nchar(2)");

            builder.Property(p => p.ProductSubcategoryID)
            .HasColumnType("int");

            builder.Property(p => p.ProductModelID)
            .HasColumnType("int");

            builder.Property(p => p.SellStartDate)
            .HasColumnType("datetime");

            builder.Property(p => p.SellEndDate)
            .HasColumnType("datetime");

            builder.Property(p => p.DiscontinuedDate)
            .HasColumnType("datetime");

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.ProductNumber })
            .IsUnique()
            .HasDatabaseName("AK_Product_ProductNumber");

            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_Product_Name");

            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_Product_rowguid");

            builder.HasIndex(e => new { e.ProductModelID })
            .HasDatabaseName("FK_Product_ProductModel_ProductModel");

            builder.HasIndex(e => new { e.ProductSubcategoryID })
            .HasDatabaseName("FK_Product_ProductSubcategory_ProductSubcategory");

            builder.HasIndex(e => new { e.SizeUnitMeasureCode })
            .HasDatabaseName("FK_Product_UnitMeasureSize_UnitMeasure");

            builder.HasIndex(e => new { e.WeightUnitMeasureCode })
            .HasDatabaseName("FK_Product_UnitMeasureWeight_UnitMeasure");

            builder.HasOne(e => e.ProductModel)
            .WithMany()
            .HasForeignKey(e => new { e.ProductModelID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Product_ProductModel_ProductModel_Constraint");

            builder.HasOne(e => e.ProductSubcategory)
            .WithMany()
            .HasForeignKey(e => new { e.ProductSubcategoryID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Product_ProductSubcategory_ProductSubcategory_Constraint");

            builder.HasOne(e => e.UnitMeasureSize)
            .WithMany()
            .HasForeignKey(e => new { e.SizeUnitMeasureCode })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Product_UnitMeasure_UnitMeasureSize_Constraint");

            builder.HasOne(e => e.UnitMeasureWeight)
            .WithMany()
            .HasForeignKey(e => new { e.WeightUnitMeasureCode })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Product_UnitMeasure_UnitMeasureWeight_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}