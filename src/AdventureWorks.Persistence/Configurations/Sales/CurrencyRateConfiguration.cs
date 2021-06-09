using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class CurrencyRateConfiguration : IEntityTypeConfiguration<CurrencyRate>
    {
        public void Configure(EntityTypeBuilder<CurrencyRate> builder)
        {
            // Name and Schema
            builder.ToTable("CurrencyRate", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.CurrencyRateID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.CurrencyRateID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.CurrencyRateDate)
            .HasColumnType("datetime");

            builder.Property(p => p.FromCurrencyCode)
            .HasColumnType("nchar(3)")
            .IsRequired();

            builder.Property(p => p.ToCurrencyCode)
            .HasColumnType("nchar(3)")
            .IsRequired();

            builder.Property(p => p.AverageRate)
            .HasColumnType("money");

            builder.Property(p => p.EndOfDayRate)
            .HasColumnType("money");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.CurrencyRateDate, e.FromCurrencyCode, e.ToCurrencyCode })
            .IsUnique()
            .HasDatabaseName("AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode");

            builder.HasIndex(e => new { e.FromCurrencyCode })
            .HasDatabaseName("FK_CurrencyRate_CurrencyFrom_Currency");

            builder.HasIndex(e => new { e.ToCurrencyCode })
            .HasDatabaseName("FK_CurrencyRate_CurrencyTo_Currency");

            builder.HasOne(e => e.CurrencyFrom)
            .WithMany(p => p.CurrencyRatesFrom)
            .HasForeignKey(e => new { e.FromCurrencyCode })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_CurrencyRate_Currency_CurrencyFrom_Constraint");

            builder.HasOne(e => e.CurrencyTo)
            .WithMany(p => p.CurrencyRatesTo)
            .HasForeignKey(e => new { e.ToCurrencyCode })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_CurrencyRate_Currency_CurrencyTo_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}