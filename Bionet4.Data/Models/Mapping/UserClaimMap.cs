using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class UserClaimMap : EntityTypeConfiguration<UserClaim>
    {
        public UserClaimMap()
        {
            this.HasKey(t => t.Id);

            this.ToTable("UserClaims");

            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(u => u.ClaimType).HasMaxLength(150);
            this.Property(u => u.ClaimValue).HasMaxLength(500);
        }
    }
}