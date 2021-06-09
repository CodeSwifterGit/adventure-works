using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Sales;

namespace AdventureWorks.Persistence.Configurations.Sales
{
    public partial class IndividualConfiguration : IEntityTypeConfiguration<Individual>
    {
        public void Configure(EntityTypeBuilder<Individual> builder)
        {
            // Name and Schema
            builder.ToTable("Individual", "Sales");

            // Primary Key
            builder.HasKey(e => new { e.CustomerID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.CustomerID)
            .HasColumnType("int");

            builder.Property(p => p.ContactID)
            .HasColumnType("int");

            builder.Property(p => p.Demographics)
            .HasColumnType("xml");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys


            builder.HasIndex(e => new { e.ContactID })
            .HasDatabaseName("FK_Individual_Contact_Contact");

            builder.HasIndex(e => new { e.CustomerID })
            .HasDatabaseName("FK_Individual_Customer_Customer");

            builder.HasOne(e => e.Contact)
            .WithMany(p => p.Individuals)
            .HasForeignKey(e => new { e.ContactID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Individual_Contact_Contact_Constraint");

            builder.HasOne(e => e.Customer)
            .WithMany(p => p.Individuals)
            .HasForeignKey(e => new { e.CustomerID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Individual_Customer_Customer_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}