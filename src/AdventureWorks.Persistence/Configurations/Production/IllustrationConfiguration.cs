using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class IllustrationConfiguration : IEntityTypeConfiguration<Illustration>
    {
        public void Configure(EntityTypeBuilder<Illustration> builder)
        {
            // Name and Schema
            builder.ToTable("Illustration", "Production");

            // Primary Key
            builder.HasKey(e => new { e.IllustrationID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.IllustrationID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.Diagram)
            .HasColumnType("xml");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValue("(getdate())");

            // Indexes and Foreign Keys






            // Complex Types (Owned properties as tables)

        }
    }
}