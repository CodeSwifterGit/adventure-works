using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class StoreContactConfiguration : IEntityTypeConfiguration<StoreContact>
    {
        public void Configure(EntityTypeBuilder<StoreContact> builder)
        {
            // Name and Schema
            builder.ToTable("StoreContact", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.CustomerID, e.ContactID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.CustomerID)
            .HasColumnType("int");

            builder.Property(p => p.ContactID)
            .HasColumnType("int");

            builder.Property(p => p.ContactTypeID)
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
            .HasDatabaseName("AK_StoreContact_rowguid");

            builder.HasIndex(e => new { e.ContactID })
            .HasDatabaseName("IX_StoreContact_ContactID");

            builder.HasIndex(e => new { e.ContactTypeID })
            .HasDatabaseName("IX_StoreContact_ContactTypeID");

            builder.HasIndex(e => new { e.ContactID })
            .HasDatabaseName("FK_StoreContact_Contact_Contact");

            builder.HasIndex(e => new { e.ContactTypeID })
            .HasDatabaseName("FK_StoreContact_ContactType_ContactType");

            builder.HasIndex(e => new { e.CustomerID })
            .HasDatabaseName("FK_StoreContact_Store_Store");

            builder.HasOne(e => e.Contact)
            .WithMany(p => p.StoreContacts)
            .HasForeignKey(e => new { e.ContactID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_StoreContact_Contact_Contact_Constraint");

            builder.HasOne(e => e.ContactType)
            .WithMany(p => p.StoreContacts)
            .HasForeignKey(e => new { e.ContactTypeID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_StoreContact_ContactType_ContactType_Constraint");

            builder.HasOne(e => e.Store)
            .WithMany(p => p.StoreContacts)
            .HasForeignKey(e => new { e.CustomerID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_StoreContact_Store_Store_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}