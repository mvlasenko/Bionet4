using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.AgentId);

            this.Property(t => t.IDLeft).HasMaxLength(255);

            this.Property(t => t.IDRight).HasMaxLength(255);

            this.Property(t => t.Discount);

            this.Property(t => t.Body).HasMaxLength(4000);

            this.Property(t => t.IsViewed);

            this.Property(t => t.CreatedDateTime).IsRequired();

            // Table & Column Mappings

            this.ToTable("Orders");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AgentId).HasColumnName("AgentId");
            this.Property(t => t.IDLeft).HasColumnName("IDLeft");
            this.Property(t => t.IDRight).HasColumnName("IDRight");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.IsViewed).HasColumnName("IsViewed");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");

            // Relationships
            this.HasRequired(t => t.Agent)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.AgentId);

            this.HasMany(e => e.OrderItems)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

        }
    }
}