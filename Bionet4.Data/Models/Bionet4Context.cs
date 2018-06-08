using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Bionet4.Data.Models.Mapping;

namespace Bionet4.Data.Models
{
    public class Bionet4Context : IdentityDbContext<Agent>
    {
        public Bionet4Context() : base("Bionet4Context", throwIfV1Schema: false)
        {
            Database.SetInitializer<Bionet4Context>(null);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static Bionet4Context Create()
        {
            return new Bionet4Context();
        }

        //Identity and Authorization
        //public DbSet<UserLogin> UserLogins { get; set; }
        //public DbSet<UserClaim> UserClaims { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AgentMap());
            modelBuilder.Configurations.Add(new AlbumDetailMap());
            modelBuilder.Configurations.Add(new AlbumMap());
            modelBuilder.Configurations.Add(new ApplicationMap());
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new BottomBannerMap());
            modelBuilder.Configurations.Add(new CertificateMap());
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new FAQMap());
            modelBuilder.Configurations.Add(new IngredientMap());
            modelBuilder.Configurations.Add(new LogoMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductForOrderMap());
            modelBuilder.Configurations.Add(new RajonMap());
            modelBuilder.Configurations.Add(new RegionMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new SliderMap());
            modelBuilder.Configurations.Add(new UnitMap());
            modelBuilder.Configurations.Add(new VariableMap());
            modelBuilder.Configurations.Add(new VideoMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Configure Asp Net Identity Tables
            //modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<User>().Property(u => u.PasswordHash).HasMaxLength(500);
            //modelBuilder.Entity<User>().Property(u => u.Stamp).HasMaxLength(500);
            //modelBuilder.Entity<User>().Property(u => u.PhoneNumber).HasMaxLength(50);

            //modelBuilder.Entity<Role>().ToTable("Role");
            //modelBuilder.Entity<UserRole>().ToTable("UserRole");
            //modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            //modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            //modelBuilder.Entity<UserClaim>().Property(u => u.ClaimType).HasMaxLength(150);
            //modelBuilder.Entity<UserClaim>().Property(u => u.ClaimValue).HasMaxLength(500);



        }
    }
}