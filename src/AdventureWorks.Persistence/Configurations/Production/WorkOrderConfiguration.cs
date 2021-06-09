using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class WorkOrderConfiguration : IEntityTypeConfiguration<WorkOrder>
    {
        public void Configure(EntityTypeBuilder<WorkOrder> builder)
        {
            // Name and Schema
            builder.ToTable("WorkOrder", "Production");

            // Primary Key
            builder.HasKey(e => new { e.WorkOrderID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.WorkOrderID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.ProductID)
            .HasColumnType("int");

            builder.Property(p => p.OrderQty)
            .HasColumnType("int");

            builder.Property(p => p.StockedQty)
            .HasColumnType("int")
            .HasComputedColumnSql("(isnull([OrderQty]-[ScrappedQty],(0)))", false);

            builder.Property(p => p.ScrappedQty)
            .HasColumnType("smallint");

            builder.Property(p => p.StartDate)
            .HasColumnType("datetime");

            builder.Property(p => p.EndDate)
            .HasColumnType("datetime");

            builder.Property(p => p.DueDate)
            .HasColumnType("datetime");

            builder.Property(p => p.ScrapReasonID)
            .HasColumnType("smallint");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.ScrapReasonID })
            .HasDatabaseName("IX_WorkOrder_ScrapReasonID");

            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("IX_WorkOrder_ProductID");

            builder.HasIndex(e => new { e.ProductID })
            .HasDatabaseName("FK_WorkOrder_Product_Product");

            builder.HasIndex(e => new { e.ScrapReasonID })
            .HasDatabaseName("FK_WorkOrder_ScrapReason_ScrapReason");

            builder.HasOne(e => e.Product)
            .WithMany(p => p.WorkOrders)
            .HasForeignKey(e => new { e.ProductID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_WorkOrder_Product_Product_Constraint");

            builder.HasOne(e => e.ScrapReason)
            .WithMany()
            .HasForeignKey(e => new { e.ScrapReasonID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_WorkOrder_ScrapReason_ScrapReason_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}