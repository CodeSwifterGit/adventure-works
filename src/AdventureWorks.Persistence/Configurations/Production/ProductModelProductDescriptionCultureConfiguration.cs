using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class ProductModelProductDescriptionCultureConfiguration : IEntityTypeConfiguration<ProductModelProductDescriptionCulture>
    {
        public void Configure(EntityTypeBuilder<ProductModelProductDescriptionCulture> builder)
        {
            // Name and Schema
            builder.ToTable("ProductModelProductDescriptionCulture", "Production");

            // Primary Key
            builder.HasKey(e => new { e.ProductModelID, e.ProductDescriptionID, e.CultureID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ProductModelID)
            .HasColumnType("int");

            builder.Property(p => p.ProductDescriptionID)
            .HasColumnType("int");

            builder.Property(p => p.CultureID)
            .HasColumnType("nchar")
            .IsRequired();

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys


            builder.HasIndex(e => new { e.CultureID })
            .HasDatabaseName("FK_ProductModelProductDescriptionCulture_Culture_Culture");

            builder.HasIndex(e => new { e.ProductDescriptionID })
            .HasDatabaseName("FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescription");

            builder.HasIndex(e => new { e.ProductModelID })
            .HasDatabaseName("FK_ProductModelProductDescriptionCulture_ProductModel_ProductModel");

            builder.HasOne(e => e.Culture)
            .WithMany(p => p.ProductModelProductDescriptionCultures)
            .HasForeignKey(e => new { e.CultureID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ProductModelProductDescriptionCulture_Culture_Culture_Constraint");

            builder.HasOne(e => e.ProductDescription)
            .WithMany(p => p.ProductModelProductDescriptionCultures)
            .HasForeignKey(e => new { e.ProductDescriptionID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescription_Constraint");

            builder.HasOne(e => e.ProductModel)
            .WithMany(p => p.ProductModelProductDescriptionCultures)
            .HasForeignKey(e => new { e.ProductModelID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ProductModelProductDescriptionCulture_ProductModel_ProductModel_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}