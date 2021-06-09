using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class SalesTaxRateConfiguration : IEntityTypeConfiguration<SalesTaxRate>
    {
        public void Configure(EntityTypeBuilder<SalesTaxRate> builder)
        {
            // Name and Schema
            builder.ToTable("SalesTaxRate", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.SalesTaxRateID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.SalesTaxRateID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.StateProvinceID)
            .HasColumnType("int");

            builder.Property(p => p.TaxType)
            .HasColumnType("tinyint");

            builder.Property(p => p.TaxRate)
            .HasColumnType("smallmoney")
            .HasDefaultValueSql("((0.00))");

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.StateProvinceID, e.TaxType })
            .IsUnique()
            .HasDatabaseName("AK_SalesTaxRate_StateProvinceID_TaxType");

            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_SalesTaxRate_rowguid");

            builder.HasIndex(e => new { e.StateProvinceID })
            .HasDatabaseName("FK_SalesTaxRate_StateProvince_StateProvince");

            builder.HasOne(e => e.StateProvince)
            .WithMany(p => p.SalesTaxRates)
            .HasForeignKey(e => new { e.StateProvinceID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_SalesTaxRate_StateProvince_StateProvince_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}