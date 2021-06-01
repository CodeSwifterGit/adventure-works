using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Persistence.Configurations.HumanResources
{
    public partial class EmployeeAddressConfiguration : IEntityTypeConfiguration<EmployeeAddress>
    {
        public void Configure(EntityTypeBuilder<EmployeeAddress> builder)
        {
            // Name and Schema
            builder.ToTable("EmployeeAddress", "HumanResources");

            // Primary Key
            builder.HasKey(e => new { e.EmployeeID, e.AddressID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.EmployeeID)
            .HasColumnType("int");

            builder.Property(p => p.AddressID)
            .HasColumnType("int");

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_EmployeeAddress_rowguid");

            builder.HasIndex(e => new { e.AddressID })
            .HasDatabaseName("FK_EmployeeAddress_Address_Address");

            builder.HasIndex(e => new { e.EmployeeID })
            .HasDatabaseName("FK_EmployeeAddress_Employee_Employee");

            builder.HasOne(e => e.Address)
            .WithMany(p => p.EmployeeAddresses)
            .HasForeignKey(e => new { e.AddressID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_EmployeeAddress_Address_Address_Constraint");

            builder.HasOne(e => e.Employee)
            .WithMany(p => p.EmployeeAddresses)
            .HasForeignKey(e => new { e.EmployeeID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_EmployeeAddress_Employee_Employee_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}