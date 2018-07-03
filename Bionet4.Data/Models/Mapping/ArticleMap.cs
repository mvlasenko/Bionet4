using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class ArticleMap : EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.ArticleType);

            this.Property(t => t.Name).IsRequired().HasMaxLength(255);

            this.Property(t => t.Description).HasMaxLength(4000);

            this.Property(t => t.ImageID).HasMaxLength(255);

            this.Property(t => t.FaIcon).HasMaxLength(20);

            this.Property(t => t.Author).HasMaxLength(255);

            this.Property(t => t.PublishDate);

            this.Property(t => t.ExternalURL).HasMaxLength(255);

            this.Property(t => t.CreatedDateTime).IsRequired();

            this.Property(t => t.SeqID);

            // Table & Column Mappings

            this.ToTable("Article");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ArticleType).HasColumnName("ArticleType");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ImageID).HasColumnName("ImageID");
            this.Property(t => t.FaIcon).HasColumnName("FaIcon");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.ExternalURL).HasColumnName("ExternalURL");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.SeqID).HasColumnName("SeqID");

            // Relationships

            this.HasMany(e => e.Paragraphs)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(true);

        }
    }
}