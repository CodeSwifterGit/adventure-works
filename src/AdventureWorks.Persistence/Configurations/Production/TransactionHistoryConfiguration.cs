using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class TransactionHistoryConfiguration : IEntityTypeConfiguration<TransactionHistory>
    {
        public void Configure(EntityTypeBuilder<TransactionHistory> builder)
        {
            // Name and Schema
            builder.ToTable("TransactionHistory", "Production");

            // Primary Key
            builder.HasKey(e => new { e.TransactionID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.TransactionID)
            .HasColumnType("int")
            .UseIdentityColumn(100000, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.ReferenceOrderID)
            .HasColumnType("int");

            builder.Property(p => p.ReferenceOrderLineID)
            .HasColumnType("int")
            .HasDefaultValueSql("((0))");

            builder.Property(p => p.TransactionDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            builder.Property(p => p.TransactionType)
            .HasColumnType("nchar(1)")
            .IsRequired();

            builder.Property(p => p.Quantity)
            .HasColumnType("int");

            builder.Property(p => p.ActualCost)
            .HasColumnType("money");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("IX_TransactionHistory_ProductID");

            builder.HasIndex(e => new { e.ReferenceOrderID, e.ReferenceOrderLineID })
            .HasDatabaseName("IX_TransactionHistory_ReferenceOrderID_ReferenceOrderLineID");

            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("FK_TransactionHistory_Product_Product");

            builder.HasOne(e => e.Product)
            .WithMany(p => p.TransactionHistories)
            .HasForeignKey(e => new { e.ProductID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_TransactionHistory_Product_Product_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}