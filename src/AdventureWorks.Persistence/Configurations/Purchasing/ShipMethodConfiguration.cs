using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Persistence.Configurations.Purchasing
{
    public partial class ShipMethodConfiguration : IEntityTypeConfiguration<ShipMethod>
    {
        public void Configure(EntityTypeBuilder<ShipMethod> builder)
        {
            // Name and Schema
            builder.ToTable("ShipMethod", "Purchasing");

            // Primary Key
            builder.HasKey(e => new { e.ShipMethodID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ShipMethodID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.ShipBase)
            .HasColumnType("money")
            .HasDefaultValueSql("((0.00))");

            builder.Property(p => p.ShipRate)
            .HasColumnType("money")
            .HasDefaultValueSql("((0.00))");

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_ShipMethod_Name");

            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_ShipMethod_rowguid");





            // Complex Types (Owned properties as tables)

        }
    }
}