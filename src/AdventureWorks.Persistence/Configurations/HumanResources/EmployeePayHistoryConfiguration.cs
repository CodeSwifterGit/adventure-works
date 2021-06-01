using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Persistence.Configurations.HumanResources
{
    public partial class EmployeePayHistoryConfiguration : IEntityTypeConfiguration<EmployeePayHistory>
    {
        public void Configure(EntityTypeBuilder<EmployeePayHistory> builder)
        {
            // Name and Schema
            builder.ToTable("EmployeePayHistory", "HumanResources");

            // Primary Key
            builder.HasKey(e => new { e.EmployeeID, e.RateChangeDate });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.EmployeeID)
            .HasColumnType("int");

            builder.Property(p => p.RateChangeDate)
            .HasColumnType("datetime");

            builder.Property(p => p.Rate)
            .HasColumnType("money");

            builder.Property(p => p.PayFrequency)
            .HasColumnType("tinyint");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys


            builder.HasIndex(e => new { e.EmployeeID })
            .HasDatabaseName("FK_EmployeePayHistory_Employee_Employee");

            builder.HasOne(e => e.Employee)
            .WithMany(p => p.EmployeePayHistories)
            .HasForeignKey(e => new { e.EmployeeID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_EmployeePayHistory_Employee_Employee_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}