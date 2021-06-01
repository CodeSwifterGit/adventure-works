using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Purchasing;

namespace AdventureWorks.Persistence.Configurations.Purchasing
{
    public partial class PurchaseOrderHeaderConfiguration : IEntityTypeConfiguration<PurchaseOrderHeader>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderHeader> builder)
        {
            // Name and Schema
            builder.ToTable("PurchaseOrderHeader", "Purchasing");

            // Primary Key
            builder.HasKey(e => new { e.PurchaseOrderID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.PurchaseOrderID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.RevisionNumber)
            .HasColumnType("tinyint")
            .HasDefaultValueSql("((0))");

            builder.Property(p => p.Status)
            .HasColumnType("tinyint")
            .HasDefaultValueSql("((1))");

            builder.Property(p => p.EmployeeID)
            .HasColumnType("int");

            builder.Property(p => p.VendorID)
            .HasColumnType("int");

            builder.Property(p => p.ShipMethodID)
            .HasColumnType("int");

            builder.Property(p => p.OrderDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            builder.Property(p => p.ShipDate)
            .HasColumnType("datetime");

            builder.Property(p => p.SubTotal)
            .HasColumnType("money")
            .HasDefaultValueSql("((0.00))");

            builder.Property(p => p.TaxAmt)
            .HasColumnType("money")
            .HasDefaultValueSql("((0.00))");

            builder.Property(p => p.Freight)
            .HasColumnType("money")
            .HasDefaultValueSql("((0.00))");

            builder.Property(p => p.TotalDue)
            .HasColumnType("money")
            .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", true);

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.VendorID })
            .HasDatabaseName("IX_PurchaseOrderHeader_VendorID");

            builder.HasIndex(e => new { e.EmployeeID })
            .HasDatabaseName("IX_PurchaseOrderHeader_EmployeeID");

            builder.HasIndex(e => new { e.EmployeeID })
            .HasDatabaseName("FK_PurchaseOrderHeader_Employee_Employee");

            builder.HasIndex(e => new { e.ShipMethodID })
            .HasDatabaseName("FK_PurchaseOrderHeader_ShipMethod_ShipMethod");

            builder.HasIndex(e => new { e.VendorID })
            .HasDatabaseName("FK_PurchaseOrderHeader_Vendor_Vendor");

            builder.HasOne(e => e.Employee)
            .WithMany(p => p.PurchaseOrderHeaders)
            .HasForeignKey(e => new { e.EmployeeID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_PurchaseOrderHeader_Employee_Employee_Constraint");

            builder.HasOne(e => e.ShipMethod)
            .WithMany(p => p.PurchaseOrderHeaders)
            .HasForeignKey(e => new { e.ShipMethodID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_PurchaseOrderHeader_ShipMethod_ShipMethod_Constraint");

            builder.HasOne(e => e.Vendor)
            .WithMany(p => p.PurchaseOrderHeaders)
            .HasForeignKey(e => new { e.VendorID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_PurchaseOrderHeader_Vendor_Vendor_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}