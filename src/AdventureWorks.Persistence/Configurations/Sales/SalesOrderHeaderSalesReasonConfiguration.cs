using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class SalesOrderHeaderSalesReasonConfiguration : IEntityTypeConfiguration<SalesOrderHeaderSalesReason>
    {
        public void Configure(EntityTypeBuilder<SalesOrderHeaderSalesReason> builder)
        {
            // Name and Schema
            builder.ToTable("SalesOrderHeaderSalesReason", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.SalesOrderID, e.SalesReasonID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.SalesOrderID)
            .HasColumnType("int");

            builder.Property(p => p.SalesReasonID)
            .HasColumnType("int");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys


            builder.HasIndex(e => new { e.SalesOrderID })
            .HasDatabaseName("FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderHeader");

            builder.HasIndex(e => new { e.SalesReasonID })
            .HasDatabaseName("FK_SalesOrderHeaderSalesReason_SalesReason_SalesReason");

            builder.HasOne(e => e.SalesOrderHeader)
            .WithMany(p => p.SalesOrderHeaderSalesReasons)
            .HasForeignKey(e => new { e.SalesOrderID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderHeader_Constraint");

            builder.HasOne(e => e.SalesReason)
            .WithMany(p => p.SalesOrderHeaderSalesReasons)
            .HasForeignKey(e => new { e.SalesReasonID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_SalesOrderHeaderSalesReason_SalesReason_SalesReason_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}