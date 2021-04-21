using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class UnitMeasureConfiguration : IEntityTypeConfiguration<UnitMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitMeasure> builder)
        {
            // Name and Schema
            builder.ToTable("UnitMeasure", "Production");

            // Primary Key
            builder.HasKey(e => new { e.UnitMeasureCode });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.UnitMeasureCode)
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
            .HasDatabaseName("AK_UnitMeasure_Name");





            // Complex Types (Owned properties as tables)

        }
    }
}