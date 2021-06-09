using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class SalesPersonQuotaHistoryConfiguration : IEntityTypeConfiguration<SalesPersonQuotaHistory>
    {
        public void Configure(EntityTypeBuilder<SalesPersonQuotaHistory> builder)
        {
            // Name and Schema
            builder.ToTable("SalesPersonQuotaHistory", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.SalesPersonID, e.QuotaDate });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.SalesPersonID)
            .HasColumnType("int");

            builder.Property(p => p.QuotaDate)
            .HasColumnType("datetime");

            builder.Property(p => p.SalesQuota)
            .HasColumnType("money");

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
            .HasDatabaseName("AK_SalesPersonQuotaHistory_rowguid");

            builder.HasIndex(e => new { e.SalesPersonID })
            .HasDatabaseName("FK_SalesPersonQuotaHistory_SalesPerson_SalesPerson");

            builder.HasOne(e => e.SalesPerson)
            .WithMany(p => p.SalesPersonQuotaHistories)
            .HasForeignKey(e => new { e.SalesPersonID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_SalesPersonQuotaHistory_SalesPerson_SalesPerson_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}