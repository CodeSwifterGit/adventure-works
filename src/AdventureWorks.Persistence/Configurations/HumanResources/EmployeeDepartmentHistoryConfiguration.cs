using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Persistence.Configurations.HumanResources
{
    public partial class EmployeeDepartmentHistoryConfiguration : IEntityTypeConfiguration<EmployeeDepartmentHistory>
    {
        public void Configure(EntityTypeBuilder<EmployeeDepartmentHistory> builder)
        {
            // Name and Schema
            builder.ToTable("EmployeeDepartmentHistory", "HumanResources");

            // Primary Key
            builder.HasKey(e => new { e.EmployeeID, e.DepartmentID, e.ShiftID, e.StartDate });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.EmployeeID)
            .HasColumnType("int");

            builder.Property(p => p.DepartmentID)
            .HasColumnType("smallint");

            builder.Property(p => p.ShiftID)
            .HasColumnType("tinyint");

            builder.Property(p => p.StartDate)
            .HasColumnType("datetime");

            builder.Property(p => p.EndDate)
            .HasColumnType("datetime");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.DepartmentID })
            .HasDatabaseName("IX_EmployeeDepartmentHistory_DepartmentID");

            builder.HasIndex(e => new { e.ShiftID })
            .HasDatabaseName("IX_EmployeeDepartmentHistory_ShiftID");

            builder.HasIndex(e => new { e.DepartmentID })
            .HasDatabaseName("FK_EmployeeDepartmentHistory_Department_Department");

            builder.HasIndex(e => new { e.EmployeeID })
            .HasDatabaseName("FK_EmployeeDepartmentHistory_Employee_Employee");

            builder.HasIndex(e => new { e.ShiftID })
            .HasDatabaseName("FK_EmployeeDepartmentHistory_Shift_Shift");

            builder.HasOne(e => e.Department)
            .WithMany(p => p.EmployeeDepartmentHistories)
            .HasForeignKey(e => new { e.DepartmentID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_EmployeeDepartmentHistory_Department_Department_Constraint");

            builder.HasOne(e => e.Employee)
            .WithMany(p => p.EmployeeDepartmentHistories)
            .HasForeignKey(e => new { e.EmployeeID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_EmployeeDepartmentHistory_Employee_Employee_Constraint");

            builder.HasOne(e => e.Shift)
            .WithMany(p => p.EmployeeDepartmentHistories)
            .HasForeignKey(e => new { e.ShiftID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_EmployeeDepartmentHistory_Shift_Shift_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}