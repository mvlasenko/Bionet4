using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class ProductForOrderMap : EntityTypeConfiguration<ProductForOrder>
    {
        public ProductForOrderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.ItemID).IsRequired();

            this.Property(t => t.ParentID).IsRequired();

            this.Property(t => t.Code).HasMaxLength(50);

            this.Property(t => t.Name).HasMaxLength(255);

            this.Property(t => t.Price);

            this.Property(t => t.Point);

            this.Property(t => t.Balance);

            this.Property(t => t.Limit);

            // Table & Column Mappings

            this.ToTable("ProductsForOrder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.ParentID).HasColumnName("ParentID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Point).HasColumnName("Point");
            this.Property(t => t.Balance).HasColumnName("Balance");
            this.Property(t => t.Limit).HasColumnName("Limit");

            // Relationships
            this.HasMany(e => e.OrderItems)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(true);
        }
    }
}