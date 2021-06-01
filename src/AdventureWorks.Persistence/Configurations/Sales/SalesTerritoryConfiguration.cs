using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class SalesTerritoryConfiguration : IEntityTypeConfiguration<SalesTerritory>
    {
        public void Configure(EntityTypeBuilder<SalesTerritory> builder)
        {
            // Name and Schema
            builder.ToTable("SalesTerritory", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.TerritoryID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.TerritoryID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.CountryRegionCode)
            .HasColumnType("nvarchar(3)")
            .IsRequired();

            builder.Property(p => p.Group)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.SalesYTD)
            .HasColumnType("money")
            .HasDefaultValueSql("((0.00))");

            builder.Property(p => p.SalesLastYear)
            .HasColumnType("money")
            .HasDefaultValueSql("((0.00))");

            builder.Property(p => p.CostYTD)
            .HasColumnType("money")
            .HasDefaultValueSql("((0.00))");

            builder.Property(p => p.CostLastYear)
            .HasColumnType("money")
            .HasDefaultValueSql("((0.00))");

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_SalesTerritory_Name");

            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_SalesTerritory_rowguid");





            // Complex Types (Owned properties as tables)

        }
    }
}