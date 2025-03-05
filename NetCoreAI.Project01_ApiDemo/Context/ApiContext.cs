using Microsoft.EntityFrameworkCore;
using NetCoreAI.Project01_ApiDemo.Entities;

namespace NetCoreAI.Project01_ApiDemo.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KT3F5S8\\AYARCI; initial catalog= APIAIDB; integrated security= true; trustservercertificate=true");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
