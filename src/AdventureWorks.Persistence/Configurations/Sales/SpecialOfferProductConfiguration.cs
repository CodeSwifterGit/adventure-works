using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class SpecialOfferProductConfiguration : IEntityTypeConfiguration<SpecialOfferProduct>
    {
        public void Configure(EntityTypeBuilder<SpecialOfferProduct> builder)
        {
            // Name and Schema
            builder.ToTable("SpecialOfferProduct", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.SpecialOfferID, e.ProductID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.SpecialOfferID)
            .HasColumnType("int");

            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_SpecialOfferProduct_rowguid");

            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("IX_SpecialOfferProduct_ProductID");

            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("FK_SpecialOfferProduct_Product_Product");

            builder.HasIndex(e => new { e.SpecialOfferID })
            .HasDatabaseName("FK_SpecialOfferProduct_SpecialOffer_SpecialOffer");

            builder.HasOne(e => e.Product)
            .WithMany(p => p.SpecialOfferProducts)
            .HasForeignKey(e => new { e.ProductID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_SpecialOfferProduct_Product_Product_Constraint");

            builder.HasOne(e => e.SpecialOffer)
            .WithMany(p => p.SpecialOfferProducts)
            .HasForeignKey(e => new { e.SpecialOfferID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_SpecialOfferProduct_SpecialOffer_SpecialOffer_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}