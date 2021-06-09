using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class ProductSubcategoryConfiguration : IEntityTypeConfiguration<ProductSubcategory>
    {
        public void Configure(EntityTypeBuilder<ProductSubcategory> builder)
        {
            // Name and Schema
            builder.ToTable("ProductSubcategory", "Production");

            // Primary Key
            builder.HasKey(e => new { e.ProductSubcategoryID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ProductSubcategoryID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.ProductCategoryID)
            .HasColumnType("int");

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_ProductSubcategory_Name");

            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_ProductSubcategory_rowguid");

            builder.HasIndex(e => new { e.ProductCategoryID })
            .HasDatabaseName("FK_ProductSubcategory_ProductCategory_ProductCategory");

            builder.HasOne(e => e.ProductCategory)
            .WithMany(p => p.ProductSubcategories)
            .HasForeignKey(e => new { e.ProductCategoryID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ProductSubcategory_ProductCategory_ProductCategory_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}