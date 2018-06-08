using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.Name).HasMaxLength(255);

            this.Property(t => t.Binary);

            this.Property(t => t.CreatedDateTime).IsRequired();

            // Table & Column Mappings

            this.ToTable("Images");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Binary).HasColumnName("Binary");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");

            // Relationships
        }
    }
}