using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Persistence.Configurations.Purchasing
{
    public partial class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            // Name and Schema
            builder.ToTable("Vendor", "Purchasing");

            // Primary Key
            builder.HasKey(e => new { e.VendorID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.VendorID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.AccountNumber)
            .HasColumnType("nvarchar(15)")
            .IsRequired();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.CreditRating)
            .HasColumnType("tinyint");

            builder.Property(p => p.PreferredVendorStatus)
            .HasColumnType("bit")
            .HasDefaultValueSql("((1))");

            builder.Property(p => p.ActiveFlag)
            .HasColumnType("bit")
            .HasDefaultValueSql("((1))");

            builder.Property(p => p.PurchasingWebServiceURL)
            .HasColumnType("nvarchar(1024)");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.AccountNumber })
            .IsUnique()
            .HasDatabaseName("AK_Vendor_AccountNumber");





            // Complex Types (Owned properties as tables)

        }
    }
}