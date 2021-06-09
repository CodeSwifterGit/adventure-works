using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Persistence.Configurations.Purchasing
{
    public partial class VendorContactConfiguration : IEntityTypeConfiguration<VendorContact>
    {
        public void Configure(EntityTypeBuilder<VendorContact> builder)
        {
            // Name and Schema
            builder.ToTable("VendorContact", "Purchasing");

            // Primary Key
            builder.HasKey(e => new { e.VendorID, e.ContactID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.VendorID)
            .HasColumnType("int");

            builder.Property(p => p.ContactID)
            .HasColumnType("int");

            builder.Property(p => p.ContactTypeID)
            .HasColumnType("int");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.ContactID })
            .HasDatabaseName("IX_VendorContact_ContactID");

            builder.HasIndex(e => new { e.ContactTypeID })
            .HasDatabaseName("IX_VendorContact_ContactTypeID");

            builder.HasIndex(e => new { e.ContactID })
            .HasDatabaseName("FK_VendorContact_Contact_Contact");

            builder.HasIndex(e => new { e.ContactTypeID })
            .HasDatabaseName("FK_VendorContact_ContactType_ContactType");

            builder.HasIndex(e => new { e.VendorID })
            .HasDatabaseName("FK_VendorContact_Vendor_Vendor");

            builder.HasOne(e => e.Contact)
            .WithMany(p => p.VendorContacts)
            .HasForeignKey(e => new { e.ContactID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_VendorContact_Contact_Contact_Constraint");

            builder.HasOne(e => e.ContactType)
            .WithMany(p => p.VendorContacts)
            .HasForeignKey(e => new { e.ContactTypeID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_VendorContact_ContactType_ContactType_Constraint");

            builder.HasOne(e => e.Vendor)
            .WithMany(p => p.VendorContacts)
            .HasForeignKey(e => new { e.VendorID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_VendorContact_Vendor_Vendor_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}