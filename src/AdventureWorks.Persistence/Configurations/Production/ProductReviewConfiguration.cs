using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            // Name and Schema
            builder.ToTable("ProductReview", "Production");

            // Primary Key
            builder.HasKey(e => new { e.ProductReviewID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ProductReviewID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.ReviewerName)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.ReviewDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            builder.Property(p => p.EmailAddress)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.Rating)
            .HasColumnType("int");

            builder.Property(p => p.Comments)
            .HasColumnType("nvarchar(3850)");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.ProductID, e.ReviewerName })
            .IncludeProperties(e => new { e.Comments })
            .HasDatabaseName("IX_ProductReview_ProductID_Name");

            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("FK_ProductReview_Product_Product");

            builder.HasOne(e => e.Product)
            .WithMany(p => p.ProductReviews)
            .HasForeignKey(e => new { e.ProductID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ProductReview_Product_Product_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}