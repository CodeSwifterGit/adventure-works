using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Dbo;

namespace AdventureWorks.Persistence.Configurations.Dbo
{
    public partial class DatabaseLogConfiguration : IEntityTypeConfiguration<DatabaseLog>
    {
        public void Configure(EntityTypeBuilder<DatabaseLog> builder)
        {
            // Name and Schema
            builder.ToTable("DatabaseLog", "dbo");

            // Primary Key
            builder.HasKey(e => new { e.DatabaseLogID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.DatabaseLogID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.PostTime)
            .HasColumnType("datetime");

            builder.Property(p => p.DatabaseUser)
            .HasColumnType("nvarchar(128)")
            .IsRequired();

            builder.Property(p => p.Event)
            .HasColumnType("nvarchar(128)")
            .IsRequired();

            builder.Property(p => p.Schema)
            .HasColumnType("nvarchar(128)");

            builder.Property(p => p.Object)
            .HasColumnType("nvarchar(128)");

            builder.Property(p => p.Tsql)
            .HasColumnName("TSQL")
            .HasColumnType("nvarchar(-1)")
            .IsRequired();

            builder.Property(p => p.XmlEvent)
            .HasColumnType("xml");

            // Indexes and Foreign Keys






            // Complex Types (Owned properties as tables)

        }
    }
}