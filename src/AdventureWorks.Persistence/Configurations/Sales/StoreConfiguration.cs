using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            // Name and Schema
            builder.ToTable("Store", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.CustomerID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.CustomerID)
            .HasColumnType("int");

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.SalesPersonID)
            .HasColumnType("int");

            builder.Property(p => p.Demographics)
            .HasColumnType("xml");

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
            .HasDatabaseName("AK_Store_rowguid");

            builder.HasIndex(e => new { e.SalesPersonID })
            .HasDatabaseName("IX_Store_SalesPersonID");

            builder.HasIndex(e => new { e.CustomerID })
            .HasDatabaseName("FK_Store_Customer_Customer");

            builder.HasIndex(e => new { e.SalesPersonID })
            .HasDatabaseName("FK_Store_SalesPerson_SalesPerson");

            builder.HasOne(e => e.Customer)
            .WithMany(p => p.Stores)
            .HasForeignKey(e => new { e.CustomerID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Store_Customer_Customer_Constraint");

            builder.HasOne(e => e.SalesPerson)
            .WithMany()
            .HasForeignKey(e => new { e.SalesPersonID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Store_SalesPerson_SalesPerson_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}