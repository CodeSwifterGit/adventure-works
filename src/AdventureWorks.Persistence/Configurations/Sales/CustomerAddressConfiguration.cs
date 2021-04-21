using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            // Name and Schema
            builder.ToTable("CustomerAddress", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.CustomerID, e.AddressID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.CustomerID)
            .HasColumnType("int");

            builder.Property(p => p.AddressID)
            .HasColumnType("int");

            builder.Property(p => p.AddressTypeID)
            .HasColumnType("int");

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
            .HasDatabaseName("AK_CustomerAddress_rowguid");

            builder.HasIndex(e => new { e.AddressID })
            .HasDatabaseName("FK_CustomerAddress_Address_Address");

            builder.HasIndex(e => new { e.AddressTypeID })
            .HasDatabaseName("FK_CustomerAddress_AddressType_AddressType");

            builder.HasIndex(e => new { e.CustomerID })
            .HasDatabaseName("FK_CustomerAddress_Customer_Customer");

            builder.HasOne(e => e.Address)
            .WithMany(p => p.CustomerAddresses)
            .HasForeignKey(e => new { e.AddressID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_CustomerAddress_Address_Address_Constraint");

            builder.HasOne(e => e.AddressType)
            .WithMany(p => p.CustomerAddresses)
            .HasForeignKey(e => new { e.AddressTypeID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_CustomerAddress_AddressType_AddressType_Constraint");

            builder.HasOne(e => e.Customer)
            .WithMany(p => p.CustomerAddresses)
            .HasForeignKey(e => new { e.CustomerID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_CustomerAddress_Customer_Customer_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}