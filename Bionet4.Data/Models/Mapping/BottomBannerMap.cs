using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class BottomBannerMap : EntityTypeConfiguration<BottomBanner>
    {
        public BottomBannerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.ImageID).HasMaxLength(255);

            this.Property(t => t.Name).IsRequired().HasMaxLength(255);

            this.Property(t => t.TabID);

            this.Property(t => t.ExternalURL).HasMaxLength(255);

            this.Property(t => t.SeqID);

            // Table & Column Mappings

            this.ToTable("BottomBanners");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ImageID).HasColumnName("ImageID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TabID).HasColumnName("TabID");
            this.Property(t => t.ExternalURL).HasColumnName("ExternalURL");
            this.Property(t => t.SeqID).HasColumnName("SeqID");

            // Relationships
        }
    }
}