using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Dbo;

namespace AdventureWorks.Persistence.Configurations.Dbo
{
    public partial class AWBuildVersionConfiguration : IEntityTypeConfiguration<AWBuildVersion>
    {
        public void Configure(EntityTypeBuilder<AWBuildVersion> builder)
        {
            // Name and Schema
            builder.ToTable("AWBuildVersion", "dbo");

            // Primary Key
            builder.HasKey(e => new { e.SystemInformationID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.SystemInformationID)
            .HasColumnType("tinyint")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.DatabaseVersion)
            .HasColumnName("Database Version")
            .HasColumnType("nvarchar(25)")
            .IsRequired();

            builder.Property(p => p.VersionDate)
            .HasColumnType("datetime");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys






            // Complex Types (Owned properties as tables)

        }
    }
}