using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Person;

namespace AdventureWorks.Persistence.Configurations.Person
{
    public partial class StateProvinceConfiguration : IEntityTypeConfiguration<StateProvince>
    {
        public void Configure(EntityTypeBuilder<StateProvince> builder)
        {
            // Name and Schema
            builder.ToTable("StateProvince", "Person");

            // Primary Key
            builder.HasKey(e => new { e.StateProvinceID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.StateProvinceID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.StateProvinceCode)
            .HasColumnType("nchar")
            .IsRequired();

            builder.Property(p => p.CountryRegionCode)
            .HasColumnType("nvarchar(3)")
            .IsRequired();

            builder.Property(p => p.IsOnlyStateProvinceFlag)
            .HasColumnType("bit")
            .HasDefaultValue("((1))");

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.TerritoryID)
            .HasColumnType("int");

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValue("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValue("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_StateProvince_Name");

            builder.HasIndex(e => new { e.StateProvinceCode, e.CountryRegionCode })
            .IsUnique()
            .HasDatabaseName("AK_StateProvince_StateProvinceCode_CountryRegionCode");

            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_StateProvince_rowguid");

            builder.HasIndex(e => new { e.CountryRegionCode })
            .HasDatabaseName("FK_StateProvince_CountryRegion_CountryRegion");

            builder.HasIndex(e => new { e.TerritoryID })
            .HasDatabaseName("FK_StateProvince_SalesTerritory_SalesTerritory");

            builder.HasOne(e => e.CountryRegion)
            .WithMany(p => p.StateProvinces)
            .HasForeignKey(e => new { e.CountryRegionCode })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_StateProvince_CountryRegion_CountryRegion_Constraint");

            builder.HasOne(e => e.SalesTerritory)
            .WithMany(p => p.StateProvinces)
            .HasForeignKey(e => new { e.TerritoryID })
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_StateProvince_SalesTerritory_SalesTerritory_Constraint");

            // Complex Types (Owned properties as tables)

        }
    }
}