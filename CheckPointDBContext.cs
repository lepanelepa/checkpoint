using Microsoft.EntityFrameworkCore;
using CheckPoint.Models;

namespace CheckPoint
{
    public class CheckPointDBContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CheckPointDB");
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
