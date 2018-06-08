using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class AgentMap : EntityTypeConfiguration<Agent>
    {
        public AgentMap()
        {

            //identity properties
            this.Property(u => u.PasswordHash).HasMaxLength(500);
            this.Property(u => u.PhoneNumber).HasMaxLength(50);
            //todo


            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.UserID);

            this.Property(t => t.Code).HasMaxLength(50);

            this.Property(t => t.Name).HasMaxLength(255);

            this.Property(t => t.Description).HasMaxLength(1023);

            this.Property(t => t.ImageID).HasMaxLength(255);

            this.Property(t => t.AgentID);

            this.Property(t => t.ParentID);

            this.Property(t => t.Level);

            this.Property(t => t.Percent);

            this.Property(t => t.BeginDate);

            this.Property(t => t.Phone).HasMaxLength(50);

            this.Property(t => t.Address).HasMaxLength(255);

            this.Property(t => t.UpdatedDateTime);

            // Table & Column Mappings

            this.ToTable("Agents");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ImageID).HasColumnName("ImageID");
            this.Property(t => t.AgentID).HasColumnName("AgentID");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.Level).HasColumnName("Level");
            this.Property(t => t.Percent).HasColumnName("Percent");
            this.Property(t => t.BeginDate).HasColumnName("BeginDate");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.UpdatedDateTime).HasColumnName("UpdatedDateTime");

            // Relationships
            this.HasMany(e => e.Orders)
                .WithRequired(e => e.Agent)
                .WillCascadeOnDelete(true);

        }
    }
}