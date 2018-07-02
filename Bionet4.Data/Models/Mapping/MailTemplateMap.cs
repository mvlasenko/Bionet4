using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class MailTemplateMap : EntityTypeConfiguration<MailTemplate>
    {
        public MailTemplateMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.MailType);
            this.Property(t => t.Description).HasMaxLength(4000);

            // Table & Column Mappings

            this.ToTable("MailTemplates");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MailType).HasColumnName("MailType");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
        }
    }
}