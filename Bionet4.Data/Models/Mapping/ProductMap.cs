using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
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

            this.ToTable("Products");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ImagePath).HasColumnName("ImagePath");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");

            // Relationships

            this.HasOptional(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.CategoryId);

        }
    }
}