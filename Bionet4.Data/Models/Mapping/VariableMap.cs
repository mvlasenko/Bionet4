using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class VariableMap : EntityTypeConfiguration<Variable>
    {
        public VariableMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.Name).HasMaxLength(255);

            this.Property(t => t.Value).HasMaxLength(255);

            this.Property(t => t.BigValue).HasMaxLength(4000);

            // Table & Column Mappings

            this.ToTable("Variables");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.BigValue).HasColumnName("BigValue");

            // Relationships
        }
    }
}