using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Bionet4.Data.Models.Mapping;

namespace Bionet4.Data.Models
{
    public class Bionet4Context : DbContext
    {
        public Bionet4Context()
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AgentMap());
            modelBuilder.Configurations.Add(new AlbumDetailMap());
            modelBuilder.Configurations.Add(new AlbumMap());
            modelBuilder.Configurations.Add(new ApplicationMap());
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new MailTemplateMap());
            modelBuilder.Configurations.Add(new ParagraphMap());
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new FAQMap());
            modelBuilder.Configurations.Add(new IngredientMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductForOrderMap());
            modelBuilder.Configurations.Add(new RajonMap());
            modelBuilder.Configurations.Add(new RegionMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new VariableMap());
            modelBuilder.Configurations.Add(new VideoMap());
            modelBuilder.Configurations.Add(new ImageMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<Bionet4.Data.Models.Article> Articles { get; set; }

        public System.Data.Entity.DbSet<Bionet4.Data.Models.Paragraph> Paragraphs { get; set; }
    }
}