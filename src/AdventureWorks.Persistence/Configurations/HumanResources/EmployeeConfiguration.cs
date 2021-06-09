using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Persistence.Configurations.HumanResources
{
    public partial class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Name and Schema
            builder.ToTable("Employee", "HumanResources");

            // Primary Key
            builder.HasKey(e => new { e.EmployeeID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.EmployeeID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.NationalIDNumber)
            .HasColumnType("nvarchar(15)")
            .IsRequired();

            builder.Property(p => p.ContactID)
            .HasColumnType("int");

            builder.Property(p => p.LoginID)
            .HasColumnType("nvarchar(256)")
            .IsRequired();

            builder.Property(p => p.ManagerID)
            .HasColumnType("int");

            builder.Property(p => p.Title)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.BirthDate)
            .HasColumnType("datetime");

            builder.Property(p => p.MaritalStatus)
            .HasColumnType("nchar(1)")
            .IsRequired();

            builder.Property(p => p.Gender)
            .HasColumnType("nchar(1)")
            .IsRequired();

            builder.Property(p => p.HireDate)
            .HasColumnType("datetime");

            builder.Property(p => p.SalariedFlag)
            .HasColumnType("bit")
            .HasDefaultValueSql("((1))");

            builder.Property(p => p.VacationHours)
            .HasColumnType("smallint")
            .HasDefaultValueSql("((0))");

            builder.Property(p => p.SickLeaveHours)
            .HasColumnType("smallint")
            .HasDefaultValueSql("((0))");

            builder.Property(p => p.CurrentFlag)
            .HasColumnType("bit")
            .HasDefaultValueSql("((1))");

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.LoginID })
            .IsUnique()
            .HasDatabaseName("AK_Employee_LoginID");

            builder.HasIndex(e => new { e.NationalIDNumber })
            .IsUnique()
            .HasDatabaseName("AK_Employee_NationalIDNumber");

            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_Employee_rowguid");

            builder.HasIndex(e => new { e.ManagerID })
            .HasDatabaseName("IX_Employee_ManagerID");

            builder.HasIndex(e => new { e.ContactID })
            .HasDatabaseName("FK_Employee_Contact_Contact");

            builder.HasIndex(e => new { e.ManagerID })
            .HasDatabaseName("FK_Employee_Manager_Employee");

            builder.HasOne(e => e.Contact)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => new { e.ContactID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Employee_Contact_Contact_Constraint");

            builder.HasOne(e => e.Manager)
            .WithMany()
            .HasForeignKey(e => new { e.ManagerID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Employee_Employee_Manager_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}