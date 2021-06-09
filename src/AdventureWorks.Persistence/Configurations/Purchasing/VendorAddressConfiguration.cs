using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Persistence.Configurations.Purchasing
{
    public partial class VendorAddressConfiguration : IEntityTypeConfiguration<VendorAddress>
    {
        public void Configure(EntityTypeBuilder<VendorAddress> builder)
        {
            // Name and Schema
            builder.ToTable("VendorAddress", "Purchasing");

            // Primary Key
            builder.HasKey(e => new { e.VendorID, e.AddressID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.VendorID)
            .HasColumnType("int");

            builder.Property(p => p.AddressID)
            .HasColumnType("int");

            builder.Property(p => p.AddressTypeID)
            .HasColumnType("int");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.AddressID })
            .HasDatabaseName("IX_VendorAddress_AddressID");

            builder.HasIndex(e => new { e.AddressID })
            .HasDatabaseName("FK_VendorAddress_Address_Address");

            builder.HasIndex(e => new { e.AddressTypeID })
            .HasDatabaseName("FK_VendorAddress_AddressType_AddressType");

            builder.HasIndex(e => new { e.VendorID })
            .HasDatabaseName("FK_VendorAddress_Vendor_Vendor");

            builder.HasOne(e => e.Address)
            .WithMany(p => p.VendorAddresses)
            .HasForeignKey(e => new { e.AddressID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_VendorAddress_Address_Address_Constraint");

            builder.HasOne(e => e.AddressType)
            .WithMany(p => p.VendorAddresses)
            .HasForeignKey(e => new { e.AddressTypeID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_VendorAddress_AddressType_AddressType_Constraint");

            builder.HasOne(e => e.Vendor)
            .WithMany(p => p.VendorAddresses)
            .HasForeignKey(e => new { e.VendorID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_VendorAddress_Vendor_Vendor_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}