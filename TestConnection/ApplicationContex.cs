using System.Data.Entity;
using TestConnection.Tables;

namespace TestConnection
{
    public class ApplicationContex:DbContext 
    {
        public ApplicationContex():base("DefaultConnection")
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
