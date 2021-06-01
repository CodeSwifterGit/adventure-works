using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Persistence.Configurations.Person
{
    public partial class CountryRegionConfiguration : IEntityTypeConfiguration<CountryRegion>
    {
        public void Configure(EntityTypeBuilder<CountryRegion> builder)
        {
            // Name and Schema
            builder.ToTable("CountryRegion", "Person");

            // Primary Key
            builder.HasKey(e => new { e.CountryRegionCode });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.CountryRegionCode)
            .HasColumnType("nvarchar(3)")
            .IsRequired();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_CountryRegion_Name");





            // Complex Types (Owned properties as tables)

        }
    }
}