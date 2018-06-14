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

            this.Property(t => t.Name).IsRequired().HasMaxLength(255);

            this.Property(t => t.Body).HasMaxLength(4000);

            this.Property(t => t.Author).HasMaxLength(255);

            this.Property(t => t.PublishDate);

            this.Property(t => t.CreatedDateTime).IsRequired();

            // Table & Column Mappings

            this.ToTable("Article");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");

            // Relationships
        }
    }
}