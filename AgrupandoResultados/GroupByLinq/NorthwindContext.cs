using System.Data.Entity;

namespace GroupByLinq
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext() : base("Northwind")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
