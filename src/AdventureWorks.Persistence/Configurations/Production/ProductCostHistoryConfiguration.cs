using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class ProductCostHistoryConfiguration : IEntityTypeConfiguration<ProductCostHistory>
    {
        public void Configure(EntityTypeBuilder<ProductCostHistory> builder)
        {
            // Name and Schema
            builder.ToTable("ProductCostHistory", "Production");

            // Primary Key
            builder.HasKey(e => new { e.ProductID, e.StartDate });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.StartDate)
            .HasColumnType("datetime");

            builder.Property(p => p.EndDate)
            .HasColumnType("datetime");

            builder.Property(p => p.StandardCost)
            .HasColumnType("money");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys


            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("FK_ProductCostHistory_Product_Product");

            builder.HasOne(e => e.Product)
            .WithMany(p => p.ProductCostHistories)
            .HasForeignKey(e => new { e.ProductID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ProductCostHistory_Product_Product_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}