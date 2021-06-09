using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class ProductProductPhotoConfiguration : IEntityTypeConfiguration<ProductProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductProductPhoto> builder)
        {
            // Name and Schema
            builder.ToTable("ProductProductPhoto", "Production");

            // Primary Key
            builder.HasKey(e => new { e.ProductID, e.ProductPhotoID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.ProductPhotoID)
            .HasColumnType("int");

            builder.Property(p => p.Primary)
            .HasColumnType("bit")
            .HasDefaultValueSql("((0))");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys


            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("FK_ProductProductPhoto_Product_Product");

            builder.HasIndex(e => new { e.ProductPhotoID })
            .HasDatabaseName("FK_ProductProductPhoto_ProductPhoto_ProductPhoto");

            builder.HasOne(e => e.Product)
            .WithMany(p => p.ProductProductPhotos)
            .HasForeignKey(e => new { e.ProductID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ProductProductPhoto_Product_Product_Constraint");

            builder.HasOne(e => e.ProductPhoto)
            .WithMany(p => p.ProductProductPhotos)
            .HasForeignKey(e => new { e.ProductPhotoID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ProductProductPhoto_ProductPhoto_ProductPhoto_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}