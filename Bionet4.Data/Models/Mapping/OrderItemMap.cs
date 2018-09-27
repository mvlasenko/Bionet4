using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.OrderId);

            this.Property(t => t.ProductId);

            this.Property(t => t.ProductForOrderId);

            this.Property(t => t.ProductCount);

            // Table & Column Mappings

            this.ToTable("OrderItems");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.ProductForOrderId).HasColumnName("ProductForOrderId");
            this.Property(t => t.ProductCount).HasColumnName("ProductCount");

            // Relationships
            this.HasRequired(t => t.Order)
                .WithMany(t => t.OrderItems)
                .HasForeignKey(d => d.OrderId);

            this.HasOptional(t => t.Product)
                .WithMany(t => t.OrderItems)
                .HasForeignKey(d => d.ProductId);

            this.HasOptional(t => t.ProductForOrder)
                .WithMany(t => t.OrderItems)
                .HasForeignKey(d => d.ProductForOrderId);


        }
    }
}