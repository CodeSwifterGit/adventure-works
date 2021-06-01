using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class SalesTerritoryHistoryConfiguration : IEntityTypeConfiguration<SalesTerritoryHistory>
    {
        public void Configure(EntityTypeBuilder<SalesTerritoryHistory> builder)
        {
            // Name and Schema
            builder.ToTable("SalesTerritoryHistory", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.SalesPersonID, e.TerritoryID, e.StartDate });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.SalesPersonID)
            .HasColumnType("int");

            builder.Property(p => p.TerritoryID)
            .HasColumnType("int");

            builder.Property(p => p.StartDate)
            .HasColumnType("datetime");

            builder.Property(p => p.EndDate)
            .HasColumnType("datetime");

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
            .HasDatabaseName("AK_SalesTerritoryHistory_rowguid");

            builder.HasIndex(e => new { e.SalesPersonID })
            .HasDatabaseName("FK_SalesTerritoryHistory_SalesPerson_SalesPerson");

            builder.HasIndex(e => new { e.TerritoryID })
            .HasDatabaseName("FK_SalesTerritoryHistory_SalesTerritory_SalesTerritory");

            builder.HasOne(e => e.SalesPerson)
            .WithMany(p => p.SalesTerritoryHistories)
            .HasForeignKey(e => new { e.SalesPersonID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_SalesTerritoryHistory_SalesPerson_SalesPerson_Constraint");

            builder.HasOne(e => e.SalesTerritory)
            .WithMany(p => p.SalesTerritoryHistories)
            .HasForeignKey(e => new { e.TerritoryID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_SalesTerritoryHistory_SalesTerritory_SalesTerritory_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}