using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Dbo;

namespace AdventureWorks.Persistence.Configurations.Dbo
{
    public partial class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
    {
        public void Configure(EntityTypeBuilder<ErrorLog> builder)
        {
            // Name and Schema
            builder.ToTable("ErrorLog", "dbo");

            // Primary Key
            builder.HasKey(e => new { e.ErrorLogID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ErrorLogID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.ErrorTime)
            .HasColumnType("datetime")
            .HasDefaultValue("(getdate())");

            builder.Property(p => p.UserName)
            .HasColumnType("nvarchar(128)")
            .IsRequired();

            builder.Property(p => p.ErrorNumber)
            .HasColumnType("int");

            builder.Property(p => p.ErrorSeverity)
            .HasColumnType("int");

            builder.Property(p => p.ErrorState)
            .HasColumnType("int");

            builder.Property(p => p.ErrorProcedure)
            .HasColumnType("nvarchar(126)");

            builder.Property(p => p.ErrorLine)
            .HasColumnType("int");

            builder.Property(p => p.ErrorMessage)
            .HasColumnType("nvarchar(4000)")
            .IsRequired();

            // Indexes and Foreign Keys






            // Complex Types (Owned properties as tables)

        }
    }
}