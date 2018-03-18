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

            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(512);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(512);

            this.Property(t => t.ImagePath)
                .IsRequired()
                .HasMaxLength(512);

            // Table & Column Mappings

            this.ToTable("Categories");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ImagePath).HasColumnName("ImagePath");

            // Relationships

            this.HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .WillCascadeOnDelete(false);
        }
    }
}