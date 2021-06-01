using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class ProductPhotoConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            // Name and Schema
            builder.ToTable("ProductPhoto", "Production");

            // Primary Key
            builder.HasKey(e => new { e.ProductPhotoID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.ProductPhotoID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.ThumbNailPhoto)
            .HasColumnType("varbinary");

            builder.Property(p => p.ThumbnailPhotoFileName)
            .HasColumnType("nvarchar(50)");

            builder.Property(p => p.LargePhoto)
            .HasColumnType("varbinary");

            builder.Property(p => p.LargePhotoFileName)
            .HasColumnType("nvarchar(50)");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys






            // Complex Types (Owned properties as tables)

        }
    }
}