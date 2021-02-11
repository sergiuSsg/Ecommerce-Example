using System.Data.Entity;
using AMobile.Models;

namespace AMobile.DAL
{
    public class ShopContext:DbContext
    {
        public DbSet<Phone> Phones{ get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}