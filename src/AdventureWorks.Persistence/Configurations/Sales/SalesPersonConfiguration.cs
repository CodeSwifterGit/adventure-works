using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class SalesPersonConfiguration : IEntityTypeConfiguration<SalesPerson>
    {
        public void Configure(EntityTypeBuilder<SalesPerson> builder)
        {
            // Name and Schema
            builder.ToTable("SalesPerson", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.SalesPersonID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.SalesPersonID)
            .HasColumnType("int");

            builder.Property(p => p.TerritoryID)
            .HasColumnType("int");

            builder.Property(p => p.SalesQuota)
            .HasColumnType("money");

            builder.Property(p => p.Bonus)
            .HasColumnType("money")
            .HasDefaultValue("((0.00))");

            builder.Property(p => p.CommissionPct)
            .HasColumnType("smallmoney")
            .HasDefaultValue("((0.00))");

            builder.Property(p => p.SalesYTD)
            .HasColumnType("money")
            .HasDefaultValue("((0.00))");

            builder.Property(p => p.SalesLastYear)
            .HasColumnType("money")
            .HasDefaultValue("((0.00))");

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValue("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValue("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_SalesPerson_rowguid");

            builder.HasIndex(e => new { e.SalesPersonID })
            .HasDatabaseName("FK_SalesPerson_Employee_Employee");

            builder.HasIndex(e => new { e.TerritoryID })
            .HasDatabaseName("FK_SalesPerson_SalesTerritory_SalesTerritory");

            builder.HasOne(e => e.Employee)
            .WithMany(p => p.SalesPeople)
            .HasForeignKey(e => new { e.SalesPersonID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_SalesPerson_Employee_Employee_Constraint");

            builder.HasOne(e => e.SalesTerritory)
            .WithMany()
            .HasForeignKey(e => new { e.TerritoryID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_SalesPerson_SalesTerritory_SalesTerritory_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}