using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.Name).HasMaxLength(255);

            this.Property(t => t.Code).HasMaxLength(50);

            // Table & Column Mappings

            this.ToTable("Countries");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Code).HasColumnName("Code");

            // Relationships
            this.HasMany(e => e.Applications)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(true);

            this.HasMany(e => e.Regions)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(true);

        }
    }
}