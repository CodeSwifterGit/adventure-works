using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Persistence.Configurations.Person
{
    public partial class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Name and Schema
            builder.ToTable("Address", "Person");

            // Primary Key
            builder.HasKey(e => new { e.AddressID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.AddressID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.AddressLine1)
            .HasColumnType("nvarchar(60)")
            .IsRequired();

            builder.Property(p => p.AddressLine2)
            .HasColumnType("nvarchar(60)");

            builder.Property(p => p.City)
            .HasColumnType("nvarchar(30)")
            .IsRequired();

            builder.Property(p => p.StateProvinceID)
            .HasColumnType("int");

            builder.Property(p => p.PostalCode)
            .HasColumnType("nvarchar(15)")
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
            .HasDatabaseName("AK_Address_rowguid");

            builder.HasIndex(e => new { e.AddressLine1, e.AddressLine2, e.City, e.PostalCode, e.StateProvinceID })
            .IsUnique()
            .HasDatabaseName("IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode");

            builder.HasIndex(e => new { e.StateProvinceID })
            .HasDatabaseName("IX_Address_StateProvinceID");

            builder.HasIndex(e => new { e.StateProvinceID })
            .HasDatabaseName("FK_Address_StateProvince_StateProvince");

            builder.HasOne(e => e.StateProvince)
            .WithMany(p => p.Addresses)
            .HasForeignKey(e => new { e.StateProvinceID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Address_StateProvince_StateProvince_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}