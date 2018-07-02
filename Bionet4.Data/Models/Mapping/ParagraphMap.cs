using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class ParagraphMap : EntityTypeConfiguration<Paragraph>
    {
        public ParagraphMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.Name).IsRequired().HasMaxLength(255);

            this.Property(t => t.Description).HasMaxLength(4000);

            this.Property(t => t.ImageID).HasMaxLength(255);

            this.Property(t => t.FaIcon).HasMaxLength(20);

            this.Property(t => t.SeqID);

            // Table & Column Mappings

            this.ToTable("Paragraphs");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ImageID).HasColumnName("ImageID");
            this.Property(t => t.FaIcon).HasColumnName("FaIcon");
            this.Property(t => t.SeqID).HasColumnName("SeqID");

            // Relationships

            this.HasRequired(t => t.Article)
                .WithMany(t => t.Paragraphs)
                .HasForeignKey(d => d.ArticleId);

        }
    }
}