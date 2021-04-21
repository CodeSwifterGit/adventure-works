using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class CultureConfiguration : IEntityTypeConfiguration<Culture>
    {
        public void Configure(EntityTypeBuilder<Culture> builder)
        {
            // Name and Schema
            builder.ToTable("Culture", "Production");

            // Primary Key
            builder.HasKey(e => new { e.CultureID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.CultureID)
            .HasColumnType("nchar")
            .IsRequired();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValue("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_Culture_Name");





            // Complex Types (Owned properties as tables)

        }
    }
}