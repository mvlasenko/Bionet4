using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class AlbumDetailMap : EntityTypeConfiguration<AlbumDetail>
    {
        public AlbumDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.AlbumId);

            this.Property(t => t.Name).IsRequired().HasMaxLength(255);

            this.Property(t => t.ImageID).HasMaxLength(255);

            this.Property(t => t.CreatedDateTime).IsRequired();

            this.Property(t => t.SeqID);

            // Table & Column Mappings

            this.ToTable("AlbumDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AlbumId).HasColumnName("AlbumId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ImageID).HasColumnName("ImageID");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.SeqID).HasColumnName("SeqID");

            // Relationships
            this.HasRequired(t => t.Album)
                .WithMany(t => t.AlbumDetails)
                .HasForeignKey(d => d.AlbumId);

        }
    }
}