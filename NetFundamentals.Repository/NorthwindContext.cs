using NetFundamentals.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NetFundamentals.Repository
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(): base("NetFundamentals")
        {
            Database.SetInitializer<NorthwindContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Customer> Customer { get; set; }
    }
}
