using ASP_Razor.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Razor.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MyEmployeeDB");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
