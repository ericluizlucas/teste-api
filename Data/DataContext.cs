using Microsoft.EntityFrameworkCore;
using testeapi.Models;

namespace testeapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Product {  get; set; }
        public DbSet<Category> Category {  get; set; }
    }
}