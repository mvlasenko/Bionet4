using System.Data.Entity.ModelConfiguration;

namespace Bionet4.Data.Models.Mapping
{
    public class ApplicationMap : EntityTypeConfiguration<Application>
    {
        public ApplicationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.FirstName).IsRequired().HasMaxLength(50);

            this.Property(t => t.LastName).IsRequired().HasMaxLength(50);

            this.Property(t => t.MiddleName).IsRequired().HasMaxLength(50);

            this.Property(t => t.Gender).IsRequired();

            this.Property(t => t.BirthDate);

            this.Property(t => t.CountryId);

            this.Property(t => t.RegionId);

            this.Property(t => t.RajonId);

            this.Property(t => t.CityType);

            this.Property(t => t.City).HasMaxLength(50);

            this.Property(t => t.Street).HasMaxLength(255);

            this.Property(t => t.HouseNumber).HasMaxLength(10);

            this.Property(t => t.HouseNumberAddition).HasMaxLength(10);

            this.Property(t => t.Apartment).HasMaxLength(10);

            this.Property(t => t.PhoneHome).HasMaxLength(50);

            this.Property(t => t.PhoneMobile).HasMaxLength(50);

            this.Property(t => t.Email).HasMaxLength(255);

            this.Property(t => t.EnterpreneurCode).IsRequired().HasMaxLength(50);

            this.Property(t => t.Number).HasMaxLength(50);

            this.Property(t => t.CreatedDateTime).IsRequired();

            // Table & Column Mappings

            this.ToTable("Applications");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.RegionId).HasColumnName("RegionId");
            this.Property(t => t.RajonId).HasColumnName("RajonId");
            this.Property(t => t.CityType).HasColumnName("CityType");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Street).HasColumnName("Street");
            this.Property(t => t.HouseNumber).HasColumnName("HouseNumber");
            this.Property(t => t.HouseNumberAddition).HasColumnName("HouseNumberAddition");
            this.Property(t => t.Apartment).HasColumnName("Apartment");
            this.Property(t => t.PhoneHome).HasColumnName("PhoneHome");
            this.Property(t => t.PhoneMobile).HasColumnName("PhoneMobile");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.EnterpreneurCode).HasColumnName("EnterpreneurCode");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.CreatedDateTime).HasColumnName("CreatedDateTime");

            // Relationships
            this.HasRequired(t => t.Country)
                .WithMany(t => t.Applications)
                .HasForeignKey(d => d.CountryId);

            this.HasOptional(t => t.Region)
                .WithMany(t => t.Applications)
                .HasForeignKey(d => d.RegionId);

            this.HasOptional(t => t.Rajon)
                .WithMany(t => t.Applications)
                .HasForeignKey(d => d.RajonId);

        }
    }
}