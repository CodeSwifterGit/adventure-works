using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class ProductModelIllustrationConfiguration : IEntityTypeConfiguration<ProductModelIllustration>
    {
        public void Configure(EntityTypeBuilder<ProductModelIllustration> builder)
        {
            // Name and Schema
            builder.ToTable("ProductModelIllustration", "Production");

            // Primary Key
            builder.HasKey(e => new { e.ProductModelID, e.IllustrationID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ProductModelID)
            .HasColumnType("int");

            builder.Property(p => p.IllustrationID)
            .HasColumnType("int");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys


            builder.HasIndex(e => new { e.IllustrationID })
            .HasDatabaseName("FK_ProductModelIllustration_Illustration_Illustration");

            builder.HasIndex(e => new { e.ProductModelID })
            .HasDatabaseName("FK_ProductModelIllustration_ProductModel_ProductModel");

            builder.HasOne(e => e.Illustration)
            .WithMany(p => p.ProductModelIllustrations)
            .HasForeignKey(e => new { e.IllustrationID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ProductModelIllustration_Illustration_Illustration_Constraint");

            builder.HasOne(e => e.ProductModel)
            .WithMany(p => p.ProductModelIllustrations)
            .HasForeignKey(e => new { e.ProductModelID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ProductModelIllustration_ProductModel_ProductModel_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}