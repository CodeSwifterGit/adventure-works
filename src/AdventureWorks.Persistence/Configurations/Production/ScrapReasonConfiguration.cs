using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class ScrapReasonConfiguration : IEntityTypeConfiguration<ScrapReason>
    {
        public void Configure(EntityTypeBuilder<ScrapReason> builder)
        {
            // Name and Schema
            builder.ToTable("ScrapReason", "Production");

            // Primary Key
            builder.HasKey(e => new { e.ScrapReasonID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ScrapReasonID)
            .HasColumnType("smallint")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValue("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_ScrapReason_Name");





            // Complex Types (Owned properties as tables)

        }
    }
}