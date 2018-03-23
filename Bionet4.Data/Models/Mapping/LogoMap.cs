using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class LogoMap : EntityTypeConfiguration<Logo>
    {
        public LogoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.ImageURL).HasMaxLength(255);

            this.Property(t => t.Name).HasMaxLength(255);

            this.Property(t => t.TabID);

            this.Property(t => t.ExternalURL).HasMaxLength(255);

            this.Property(t => t.SeqID);

            // Table & Column Mappings

            this.ToTable("Logos");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ImageURL).HasColumnName("ImageURL");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TabID).HasColumnName("TabID");
            this.Property(t => t.ExternalURL).HasColumnName("ExternalURL");
            this.Property(t => t.SeqID).HasColumnName("SeqID");

            // Relationships
        }
    }
}