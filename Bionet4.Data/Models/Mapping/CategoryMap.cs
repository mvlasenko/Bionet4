using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.Name).HasMaxLength(255);

            this.Property(t => t.Description).HasMaxLength(4000);

            this.Property(t => t.ImageID).HasMaxLength(255);

            this.Property(t => t.ParentCategoryId);

            this.Property(t => t.SeqID);

            // Table & Column Mappings

            this.ToTable("Categories");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ImageID).HasColumnName("ImageID");
            this.Property(t => t.ParentCategoryId).HasColumnName("ParentCategoryId");
            this.Property(t => t.SeqID).HasColumnName("SeqID");

            // Relationships
            this.HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .WillCascadeOnDelete(false);

        }
    }
}