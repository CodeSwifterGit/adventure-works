using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Persistence.Configurations.Person
{
    public partial class AddressTypeConfiguration : IEntityTypeConfiguration<AddressType>
    {
        public void Configure(EntityTypeBuilder<AddressType> builder)
        {
            // Name and Schema
            builder.ToTable("AddressType", "Person");

            // Primary Key
            builder.HasKey(e => new { e.AddressTypeID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.AddressTypeID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
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
            .HasDatabaseName("AK_AddressType_rowguid");

            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_AddressType_Name");





            // Complex Types (Owned properties as tables)

        }
    }
}