using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            // Name and Schema
            builder.ToTable("Location", "Production");

            // Primary Key
            builder.HasKey(e => new { e.LocationID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.LocationID)
            .HasColumnType("smallint")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.CostRate)
            .HasColumnType("smallmoney")
            .HasDefaultValueSql("((0.00))");

            builder.Property(p => p.Availability)
            .HasColumnType("decimal(8,2)")
            .HasDefaultValueSql("((0.00))");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_Location_Name");





            // Complex Types (Owned properties as tables)

        }
    }
}