using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class SpecialOfferConfiguration : IEntityTypeConfiguration<SpecialOffer>
    {
        public void Configure(EntityTypeBuilder<SpecialOffer> builder)
        {
            // Name and Schema
            builder.ToTable("SpecialOffer", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.SpecialOfferID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.SpecialOfferID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.Description)
            .IsRequired();

            builder.Property(p => p.DiscountPct)
            .HasColumnType("smallmoney")
            .HasDefaultValue("((0.00))");

            builder.Property(p => p.Type)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.Category)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.StartDate)
            .HasColumnType("datetime");

            builder.Property(p => p.EndDate)
            .HasColumnType("datetime");

            builder.Property(p => p.MinQty)
            .HasColumnType("int")
            .HasDefaultValue("((0))");

            builder.Property(p => p.MaxQty)
            .HasColumnType("int");

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValue("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValue("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_SpecialOffer_rowguid");





            // Complex Types (Owned properties as tables)

        }
    }
}