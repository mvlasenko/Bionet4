using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class LanguageMap : EntityTypeConfiguration<Language>
    {
        public LanguageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.Code)
                .IsRequired().HasMaxLength(512);

            this.Property(t => t.Title)
                .IsRequired().HasMaxLength(512);

            // Table & Column Mappings

            this.ToTable("Languages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Title).HasColumnName("Title");

            // Relationships
        }
    }
}