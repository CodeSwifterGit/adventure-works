using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            // Name and Schema
            builder.ToTable("ShoppingCartItem", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.ShoppingCartItemID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ShoppingCartItemID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.ShoppingCartID)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.Quantity)
            .HasColumnType("int")
            .HasDefaultValueSql("((1))");

            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.DateCreated)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.ProductID, e.ShoppingCartID })
            .HasDatabaseName("IX_ShoppingCartItem_ShoppingCartID_ProductID");

            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("FK_ShoppingCartItem_Product_Product");

            builder.HasOne(e => e.Product)
            .WithMany(p => p.ShoppingCartItems)
            .HasForeignKey(e => new { e.ProductID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ShoppingCartItem_Product_Product_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}