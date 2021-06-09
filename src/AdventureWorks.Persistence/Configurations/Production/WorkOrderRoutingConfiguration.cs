using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class WorkOrderRoutingConfiguration : IEntityTypeConfiguration<WorkOrderRouting>
    {
        public void Configure(EntityTypeBuilder<WorkOrderRouting> builder)
        {
            // Name and Schema
            builder.ToTable("WorkOrderRouting", "Production");

            // Primary Key
            builder.HasKey(e => new { e.WorkOrderID, e.ProductID, e.OperationSequence });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.WorkOrderID)
            .HasColumnType("int");

            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.OperationSequence)
            .HasColumnType("smallint");

            builder.Property(p => p.LocationID)
            .HasColumnType("smallint");

            builder.Property(p => p.ScheduledStartDate)
            .HasColumnType("datetime");

            builder.Property(p => p.ScheduledEndDate)
            .HasColumnType("datetime");

            builder.Property(p => p.ActualStartDate)
            .HasColumnType("datetime");

            builder.Property(p => p.ActualEndDate)
            .HasColumnType("datetime");

            builder.Property(p => p.ActualResourceHrs)
            .HasColumnType("decimal(9,4)");

            builder.Property(p => p.PlannedCost)
            .HasColumnType("money");

            builder.Property(p => p.ActualCost)
            .HasColumnType("money");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("IX_WorkOrderRouting_ProductID");

            builder.HasIndex(e => new { e.LocationID })
            .HasDatabaseName("FK_WorkOrderRouting_Location_Location");

            builder.HasIndex(e => new { e.WorkOrderID })
            .HasDatabaseName("FK_WorkOrderRouting_WorkOrder_WorkOrder");

            builder.HasOne(e => e.Location)
            .WithMany(p => p.WorkOrderRoutings)
            .HasForeignKey(e => new { e.LocationID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_WorkOrderRouting_Location_Location_Constraint");

            builder.HasOne(e => e.WorkOrder)
            .WithMany(p => p.WorkOrderRoutings)
            .HasForeignKey(e => new { e.WorkOrderID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_WorkOrderRouting_WorkOrder_WorkOrder_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}