using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class IngredientMap : EntityTypeConfiguration<Ingredient>
    {
        public IngredientMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.HeadLetter).IsRequired().HasMaxLength(4);

            this.Property(t => t.Name).IsRequired().HasMaxLength(255);

            this.Property(t => t.Description).HasMaxLength(4000);

            this.Property(t => t.ImageURL).HasMaxLength(255);

            // Table & Column Mappings

            this.ToTable("Ingredients");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.HeadLetter).HasColumnName("HeadLetter");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ImageURL).HasColumnName("ImageURL");

            // Relationships
        }
    }
}