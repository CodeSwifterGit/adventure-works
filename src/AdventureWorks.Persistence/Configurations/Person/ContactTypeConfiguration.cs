using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Persistence.Configurations.Person
{
    public partial class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            // Name and Schema
            builder.ToTable("ContactType", "Person");

            // Primary Key
            builder.HasKey(e => new { e.ContactTypeID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ContactTypeID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_ContactType_Name");





            // Complex Types (Owned properties as tables)

        }
    }
}