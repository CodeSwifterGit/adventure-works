using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class BillOfMaterialsConfiguration : IEntityTypeConfiguration<BillOfMaterials>
    {
        public void Configure(EntityTypeBuilder<BillOfMaterials> builder)
        {
            // Name and Schema
            builder.ToTable("BillOfMaterials", "Production");

            // Primary Key
            builder.HasKey(e => new { e.BillOfMaterialsID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.BillOfMaterialsID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.ProductAssemblyID)
            .HasColumnType("int");

            builder.Property(p => p.ComponentID)
            .HasColumnType("int");

            builder.Property(p => p.StartDate)
            .HasColumnType("datetime")
            .HasDefaultValue("(getdate())");

            builder.Property(p => p.EndDate)
            .HasColumnType("datetime");

            builder.Property(p => p.UnitMeasureCode)
            .HasColumnType("nchar")
            .IsRequired();

            builder.Property(p => p.BOMLevel)
            .HasColumnType("smallint");

            builder.Property(p => p.PerAssemblyQty)
            .HasColumnType("decimal(8,2)")
            .HasDefaultValue("((1.00))");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValue("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.ComponentID, e.ProductAssemblyID, e.StartDate })
            .IsUnique()
            .IsClustered()
            .HasDatabaseName("AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate");

            builder.HasIndex(e => new { e.UnitMeasureCode })
            .HasDatabaseName("IX_BillOfMaterials_UnitMeasureCode");

            builder.HasIndex(e => new { e.ComponentID })
            .HasDatabaseName("FK_BillOfMaterials_Product_Product");

            builder.HasIndex(e => new { e.ProductAssemblyID })
            .HasDatabaseName("FK_BillOfMaterials_Product_Product");

            builder.HasIndex(e => new { e.UnitMeasureCode })
            .HasDatabaseName("FK_BillOfMaterials_UnitMeasure_UnitMeasure");

            builder.HasOne(e => e.Product)
            .WithMany(p => p.BillOfMaterials)
            .HasForeignKey(e => new { e.ComponentID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_BillOfMaterials_Product_Product_Constraint");

            builder.HasOne(e => e.Product)
            .WithMany()
            .HasForeignKey(e => new { e.ProductAssemblyID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_BillOfMaterials_Product_Product_Constraint");

            builder.HasOne(e => e.UnitMeasure)
            .WithMany(p => p.BillOfMaterials)
            .HasForeignKey(e => new { e.UnitMeasureCode })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_BillOfMaterials_UnitMeasure_UnitMeasure_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}