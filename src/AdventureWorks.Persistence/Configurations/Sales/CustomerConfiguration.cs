using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Name and Schema
            builder.ToTable("Customer", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.CustomerID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.CustomerID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.TerritoryID)
            .HasColumnType("int");

            builder.Property(p => p.AccountNumber)
            .HasColumnType("varchar(10)")
            .HasComputedColumnSql("(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))", false)
            .IsRequired();

            builder.Property(p => p.CustomerType)
            .HasColumnType("nchar")
            .IsRequired();

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
            .HasDatabaseName("AK_Customer_rowguid");

            builder.HasIndex(e => new { e.AccountNumber })
            .IsUnique()
            .HasDatabaseName("AK_Customer_AccountNumber");

            builder.HasIndex(e => new { e.TerritoryID })
            .HasDatabaseName("IX_Customer_TerritoryID");

            builder.HasIndex(e => new { e.TerritoryID })
            .HasDatabaseName("FK_Customer_SalesTerritory_SalesTerritory");

            builder.HasOne(e => e.SalesTerritory)
            .WithMany()
            .HasForeignKey(e => new { e.TerritoryID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Customer_SalesTerritory_SalesTerritory_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}