using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class ProductModelConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            // Name and Schema
            builder.ToTable("ProductModel", "Production");

            // Primary Key
            builder.HasKey(e => new { e.ProductModelID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ProductModelID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.CatalogDescription)
            .HasColumnType("xml");

            builder.Property(p => p.Instructions)
            .HasColumnType("xml");

            builder.Property(p => p.Rowguid)
            .HasColumnName("rowguid")
            .HasColumnType("uniqueidentifier")
            .HasDefaultValueSql("(newid())");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.Name })
            .IsUnique()
            .HasDatabaseName("AK_ProductModel_Name");

            builder.HasIndex(e => new { e.Rowguid })
            .IsUnique()
            .HasDatabaseName("AK_ProductModel_rowguid");





            // Complex Types (Owned properties as tables)

        }
    }
}