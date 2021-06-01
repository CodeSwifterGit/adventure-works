using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class TransactionHistoryArchiveConfiguration : IEntityTypeConfiguration<TransactionHistoryArchive>
    {
        public void Configure(EntityTypeBuilder<TransactionHistoryArchive> builder)
        {
            // Name and Schema
            builder.ToTable("TransactionHistoryArchive", "Production");

            // Primary Key
            builder.HasKey(e => new { e.TransactionID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.TransactionID)
            .HasColumnType("int");

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
            .HasColumnType("nchar")
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
            .HasDatabaseName("IX_TransactionHistoryArchive_ProductID");

            builder.HasIndex(e => new { e.ReferenceOrderID, e.ReferenceOrderLineID })
            .HasDatabaseName("IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID");





            // Complex Types (Owned properties as tables)

        }
    }
}