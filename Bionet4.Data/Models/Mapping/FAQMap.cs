using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class FAQMap : EntityTypeConfiguration<FAQ>
    {
        public FAQMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.UserName).HasMaxLength(255);

            this.Property(t => t.Email).HasMaxLength(255);

            this.Property(t => t.Question).HasMaxLength(255);

            this.Property(t => t.Answer).HasMaxLength(255);

            this.Property(t => t.CreatedDateTime).IsRequired();

            this.Property(t => t.CreatedByUserID).IsRequired();

            this.Property(t => t.ModifiedDateTime);

            this.Property(t => t.ModifiedByUserID);

            this.Property(t => t.IsApproved);

            this.Property(t => t.SeqID);

            // Table & Column Mappings

            this.ToTable("FAQ");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Question).HasColumnName("Question");
            this.Property(t => t.Answer).HasColumnName("Answer");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");
            this.Property(t => t.CreatedByUserID).HasColumnName("CreatedByUserID");
            this.Property(t => t.ModifiedDateTime).HasColumnName("ModifiedDateTime");
            this.Property(t => t.ModifiedByUserID).HasColumnName("ModifiedByUserID");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.SeqID).HasColumnName("SeqID");

            // Relationships
        }
    }
}