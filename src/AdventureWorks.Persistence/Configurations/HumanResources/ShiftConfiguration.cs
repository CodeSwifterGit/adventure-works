using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Persistence.Configurations.HumanResources
{
    public partial class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            // Name and Schema
            builder.ToTable("Shift", "HumanResources");

            // Primary Key
            builder.HasKey(e => new { e.ShiftID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ShiftID)
            .HasColumnType("tinyint")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.StartTime)
            .HasColumnType("datetime");

            builder.Property(p => p.EndTime)
            .HasColumnType("datetime");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_Shift_Name");

            builder.HasIndex(e => new { e.EndTime, e.StartTime })
            .IsUnique()
            .HasDatabaseName("AK_Shift_StartTime_EndTime");





            // Complex Types (Owned properties as tables)

        }
    }
}