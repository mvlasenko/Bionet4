using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class RajonMap : EntityTypeConfiguration<Rajon>
    {
        public RajonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.Name).HasMaxLength(255);

            this.Property(t => t.Code).HasMaxLength(50);

            this.Property(t => t.RegionId);

            // Table & Column Mappings

            this.ToTable("Rajons");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.RegionId).HasColumnName("RegionId");

            // Relationships
            this.HasRequired(t => t.Region)
                .WithMany(t => t.Rajons)
                .HasForeignKey(d => d.RegionId);

            this.HasMany(e => e.Applications)
                .WithOptional(e => e.Rajon)
                .WillCascadeOnDelete(false);

        }
    }
}