using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Persistence.Configurations.Person
{
    public partial class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            // Name and Schema
            builder.ToTable("Contact", "Person");

            // Primary Key
            builder.HasKey(e => new { e.ContactID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ContactID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.NameStyle)
            .HasColumnType("bit")
            .HasDefaultValue("((0))");

            builder.Property(p => p.Title)
            .HasColumnType("varchar(255)");

            builder.Property(p => p.FirstName)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.MiddleName)
            .HasColumnType("nvarchar(50)");

            builder.Property(p => p.LastName)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.Suffix)
            .HasColumnType("nvarchar(10)");

            builder.Property(p => p.EmailAddress)
            .HasColumnType("nvarchar(50)");

            builder.Property(p => p.EmailPromotion)
            .HasColumnType("int")
            .HasDefaultValue("((0))");

            builder.Property(p => p.Phone)
            .HasColumnType("nvarchar(25)");

            builder.Property(p => p.PasswordHash)
            .HasColumnType("varchar(255)")
            .IsRequired();

            builder.Property(p => p.PasswordSalt)
            .HasColumnType("varchar(10)")
            .IsRequired();

            builder.Property(p => p.AdditionalContactInfo)
            .HasColumnType("xml");

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
            .HasDatabaseName("AK_Contact_rowguid");

            builder.HasIndex(e => new { e.EmailAddress })
            .HasDatabaseName("IX_Contact_EmailAddress");

            builder.HasIndex(e => new { e.AdditionalContactInfo })
            .HasDatabaseName("PXML_Contact_AddContact");





            // Complex Types (Owned properties as tables)

        }
    }
}