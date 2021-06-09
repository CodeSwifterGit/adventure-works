using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class ProductDocumentConfiguration : IEntityTypeConfiguration<ProductDocument>
    {
        public void Configure(EntityTypeBuilder<ProductDocument> builder)
        {
            // Name and Schema
            builder.ToTable("ProductDocument", "Production");

            // Primary Key
            builder.HasKey(e => new { e.ProductID, e.DocumentID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.DocumentID)
            .HasColumnType("int");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys


            builder.HasIndex(e => new { e.DocumentID })
            .HasDatabaseName("FK_ProductDocument_Document_Document");

            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("FK_ProductDocument_Product_Product");

            builder.HasOne(e => e.Document)
            .WithMany(p => p.ProductDocuments)
            .HasForeignKey(e => new { e.DocumentID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ProductDocument_Document_Document_Constraint");

            builder.HasOne(e => e.Product)
            .WithMany(p => p.ProductDocuments)
            .HasForeignKey(e => new { e.ProductID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ProductDocument_Product_Product_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}