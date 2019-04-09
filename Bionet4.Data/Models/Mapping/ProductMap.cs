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

            this.Property(t => t.Name).HasMaxLength(255);

            this.Property(t => t.Description).HasMaxLength(4000);

            this.Property(t => t.ShortDescription).HasMaxLength(4000);

            this.Property(t => t.ImageID).HasMaxLength(255);

            this.Property(t => t.Price);

            this.Property(t => t.PriceNew);

            this.Property(t => t.Code).HasMaxLength(10);

            this.Property(t => t.Unit);

            this.Property(t => t.CategoryId);

            this.Property(t => t.New);

            this.Property(t => t.Bestseller);

            this.Property(t => t.CreatedDateTime).IsRequired();

            this.Property(t => t.SeqID);

            // Table & Column Mappings

            this.ToTable("Products");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ShortDescription).HasColumnName("ShortDescription");
            this.Property(t => t.ImageID).HasColumnName("ImageID");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.PriceNew).HasColumnName("PriceNew");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.New).HasColumnName("New");
            this.Property(t => t.Bestseller).HasColumnName("Bestseller");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.SeqID).HasColumnName("SeqID");

            // Relationships

            this.HasOptional(t => t.Category)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.CategoryId);

            this.HasMany(e => e.OrderItems)
                .WithOptional(e => e.Product)
                .WillCascadeOnDelete(false);

        }
    }
}