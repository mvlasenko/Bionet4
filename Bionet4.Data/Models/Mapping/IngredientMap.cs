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

            this.Property(t => t.Title)
                .IsRequired().HasMaxLength(512);

            this.Property(t => t.Amount)
                .IsRequired().HasMaxLength(512);

            this.Property(t => t.Measure)
                .IsRequired().HasMaxLength(512);

            // Table & Column Mappings

            this.ToTable("Ingredients");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.Measure).HasColumnName("Measure");

            // Relationships
        }
    }
}