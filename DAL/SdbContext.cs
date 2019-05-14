using BLL.Models;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class SdbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public  DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SaabDb;Trusted_Connection=True;");
        }
    }
}
