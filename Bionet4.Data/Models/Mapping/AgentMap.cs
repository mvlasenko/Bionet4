using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class AgentMap : EntityTypeConfiguration<Agent>
    {
        public AgentMap()
        {
            //identity properties

            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.EmailConfirmed).HasColumnName("EmailConfirmed");
            this.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            this.Property(t => t.SecurityStamp).HasColumnName("SecurityStamp");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.PhoneNumberConfirmed).HasColumnName("PhoneNumberConfirmed");
            this.Property(t => t.TwoFactorEnabled).HasColumnName("TwoFactorEnabled");
            this.Property(t => t.LockoutEndDateUtc).HasColumnName("LockoutEndDateUtc");
            this.Property(t => t.LockoutEnabled).HasColumnName("LockoutEnabled");
            this.Property(t => t.AccessFailedCount).HasColumnName("AccessFailedCount");
            this.Property(t => t.UserName).HasColumnName("UserName");

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