using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.HumanResources;

namespace AdventureWorks.Persistence.Configurations.HumanResources
{
    public partial class JobCandidateConfiguration : IEntityTypeConfiguration<JobCandidate>
    {
        public void Configure(EntityTypeBuilder<JobCandidate> builder)
        {
            // Name and Schema
            builder.ToTable("JobCandidate", "HumanResources");

            // Primary Key
            builder.HasKey(e => new { e.JobCandidateID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.JobCandidateID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.EmployeeID)
            .HasColumnType("int");

            builder.Property(p => p.Resume)
            .HasColumnType("xml");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.EmployeeID })
            .HasDatabaseName("IX_JobCandidate_EmployeeID");

            builder.HasIndex(e => new { e.EmployeeID })
            .HasDatabaseName("FK_JobCandidate_Employee_Employee");

            builder.HasOne(e => e.Employee)
            .WithMany()
            .HasForeignKey(e => new { e.EmployeeID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_JobCandidate_Employee_Employee_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}