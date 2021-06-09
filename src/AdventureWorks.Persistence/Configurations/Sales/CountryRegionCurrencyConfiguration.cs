using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class CountryRegionCurrencyConfiguration : IEntityTypeConfiguration<CountryRegionCurrency>
    {
        public void Configure(EntityTypeBuilder<CountryRegionCurrency> builder)
        {
            // Name and Schema
            builder.ToTable("CountryRegionCurrency", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.CountryRegionCode, e.CurrencyCode });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.CountryRegionCode)
            .HasColumnType("nvarchar(3)")
            .IsRequired();

            builder.Property(p => p.CurrencyCode)
            .HasColumnType("nchar(3)")
            .IsRequired();

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.CurrencyCode })
            .HasDatabaseName("IX_CountryRegionCurrency_CurrencyCode");

            builder.HasIndex(e => new { e.CountryRegionCode })
            .HasDatabaseName("FK_CountryRegionCurrency_CountryRegion_CountryRegion");

            builder.HasIndex(e => new { e.CurrencyCode })
            .HasDatabaseName("FK_CountryRegionCurrency_Currency_Currency");

            builder.HasOne(e => e.CountryRegion)
            .WithMany(p => p.CountryRegionCurrencies)
            .HasForeignKey(e => new { e.CountryRegionCode })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_CountryRegionCurrency_CountryRegion_CountryRegion_Constraint");

            builder.HasOne(e => e.Currency)
            .WithMany(p => p.CountryRegionCurrencies)
            .HasForeignKey(e => new { e.CurrencyCode })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_CountryRegionCurrency_Currency_Currency_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}