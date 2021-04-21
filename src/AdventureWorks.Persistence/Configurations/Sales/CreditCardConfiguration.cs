using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            // Name and Schema
            builder.ToTable("CreditCard", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.CreditCardID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.CreditCardID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.CardType)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.CardNumber)
            .HasColumnType("nvarchar(25)")
            .IsRequired();

            builder.Property(p => p.ExpMonth)
            .HasColumnType("tinyint");

            builder.Property(p => p.ExpYear)
            .HasColumnType("smallint");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValue("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.CardNumber })
            .IsUnique()
            .HasDatabaseName("AK_CreditCard_CardNumber");





            // Complex Types (Owned properties as tables)

        }
    }
}