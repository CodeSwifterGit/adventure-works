using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdventureWorks.Domain.Entities.Production;

namespace AdventureWorks.Persistence.Configurations.Production
{
    public partial class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            // Name and Schema
            builder.ToTable("Document", "Production");

            // Primary Key
            builder.HasKey(e => new { e.DocumentID });

            // Ignored Properties

            // Properties Configuration
            builder.Property(p => p.DocumentID)
            .HasColumnType("int")
            .UseIdentityColumn(1, 1)
            .ValueGeneratedOnAdd();

            builder.Property(p => p.Title)
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(p => p.FileName)
            .HasColumnType("nvarchar(400)")
            .IsRequired();

            builder.Property(p => p.FileExtension)
            .HasColumnType("nvarchar(8)")
            .IsRequired();

            builder.Property(p => p.Revision)
            .HasColumnType("nchar")
            .IsRequired();

            builder.Property(p => p.ChangeNumber)
            .HasColumnType("int")
            .HasDefaultValueSql("((0))");

            builder.Property(p => p.Status)
            .HasColumnType("tinyint");

            builder.Property(p => p.DocumentSummary)
            .HasColumnType("nvarchar(-1)");

            builder.Property(p => p.Document)
            .HasColumnType("varbinary");

            builder.Property(p => p.ModifiedDate)
            .HasColumnType("datetime")
            .HasDefaultValueSql("(getdate())");

            // Indexes and Foreign Keys
            builder.HasIndex(e => new { e.FileName, e.Revision })
            .IsUnique()
            .HasDatabaseName("AK_Document_FileName_Revision");





            // Complex Types (Owned properties as tables)

        }
    }
}