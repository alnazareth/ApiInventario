using Microsoft.EntityFrameworkCore;
using SistemaInventario.Models;

namespace SistemaInventario.Data
{
    public class InventarioContext: DbContext
    {

        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
