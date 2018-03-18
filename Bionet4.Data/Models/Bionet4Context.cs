using Bionet4.Data.Models.Mapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new LanguageMap());
            modelBuilder.Configurations.Add(new IngredientMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
