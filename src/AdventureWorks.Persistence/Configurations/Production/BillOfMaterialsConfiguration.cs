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
            .HasDefaultValueSql("(getdate())");

            builder.Property(p => p.EndDate)
            .HasColumnType("datetime");

            builder.Property(p => p.UnitMeasureCode)
            .HasColumnType("nchar(3)")
            .IsRequired();

            builder.Property(p => p.BOMLevel)
            .HasColumnType("smallint");

            builder.Property(p => p.PerAssemblyQty)
            .HasColumnType("decimal(8,2)")
            .HasDefaultValueSql("((1.00))");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.ComponentID, e.ProductAssemblyID, e.StartDate })
            .IsUnique()
            .HasDatabaseName("AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate");

            builder.HasIndex(e => new { e.UnitMeasureCode })
            .HasDatabaseName("IX_BillOfMaterials_UnitMeasureCode");

            builder.HasIndex(e => new { e.ComponentID })
            .HasDatabaseName("FK_BillOfMaterials_ComponentProduct_Product");

            builder.HasIndex(e => new { e.ProductAssemblyID })
            .HasDatabaseName("FK_BillOfMaterials_AssemblyProduct_Product");

            builder.HasIndex(e => new { e.UnitMeasureCode })
            .HasDatabaseName("FK_BillOfMaterials_UnitMeasure_UnitMeasure");

            builder.HasOne(e => e.ComponentProduct)
            .WithMany(p => p.BillOfMaterialsForComponents)
            .HasForeignKey(e => new { e.ComponentID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_BillOfMaterials_Product_ComponentProduct_Constraint");

            builder.HasOne(e => e.AssemblyProduct)
            .WithMany()
            .HasForeignKey(e => new { e.ProductAssemblyID })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_BillOfMaterials_Product_AssemblyProduct_Constraint");

            builder.HasOne(e => e.UnitMeasure)
            .WithMany(p => p.BillOfMaterials)
            .HasForeignKey(e => new { e.UnitMeasureCode })
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_BillOfMaterials_UnitMeasure_UnitMeasure_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}