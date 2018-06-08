using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class RegionMap : EntityTypeConfiguration<Region>
    {
        public RegionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.Name).HasMaxLength(255);

            this.Property(t => t.Code).HasMaxLength(50);

            this.Property(t => t.CountryId);

            // Table & Column Mappings

            this.ToTable("Regions");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.CountryId).HasColumnName("CountryId");

            // Relationships
            this.HasRequired(t => t.Country)
                .WithMany(t => t.Regions)
                .HasForeignKey(d => d.CountryId);

            this.HasMany(e => e.Applications)
                .WithOptional(e => e.Region)
                .WillCascadeOnDelete(false);

            this.HasMany(e => e.Rajons)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(true);

        }
    }
}