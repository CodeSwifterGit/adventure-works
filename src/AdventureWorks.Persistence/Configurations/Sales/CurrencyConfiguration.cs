using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            // Name and Schema
            builder.ToTable("Currency", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.CurrencyCode });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.CurrencyCode)
            .HasColumnType("nchar")
            .IsRequired();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_Currency_Name");





            // Complex Types (Owned properties as tables)

        }
    }
}