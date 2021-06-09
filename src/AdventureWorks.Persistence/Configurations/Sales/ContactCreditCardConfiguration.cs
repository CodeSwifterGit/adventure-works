using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class ContactCreditCardConfiguration : IEntityTypeConfiguration<ContactCreditCard>
    {
        public void Configure(EntityTypeBuilder<ContactCreditCard> builder)
        {
            // Name and Schema
            builder.ToTable("ContactCreditCard", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.ContactID, e.CreditCardID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ContactID)
            .HasColumnType("int");

            builder.Property(p => p.CreditCardID)
            .HasColumnType("int");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys


            builder.HasIndex(e => new { e.ContactID })
            .HasDatabaseName("FK_ContactCreditCard_Contact_Contact");

            builder.HasIndex(e => new { e.CreditCardID })
            .HasDatabaseName("FK_ContactCreditCard_CreditCard_CreditCard");

            builder.HasOne(e => e.Contact)
            .WithMany(p => p.ContactCreditCards)
            .HasForeignKey(e => new { e.ContactID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ContactCreditCard_Contact_Contact_Constraint");

            builder.HasOne(e => e.CreditCard)
            .WithMany(p => p.ContactCreditCards)
            .HasForeignKey(e => new { e.CreditCardID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ContactCreditCard_CreditCard_CreditCard_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}