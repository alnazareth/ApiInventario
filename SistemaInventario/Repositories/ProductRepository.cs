using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data;
using SistemaInventario.Models;

namespace SistemaInventario.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventarioContext _context;

        public ProductRepository(InventarioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        /*
        public async Task<Dictionary<string, List<Product>>> GetAllProductsAsync()
        {
            return await _context.Products
        .GroupBy(p => p.Status)
        .ToDictionaryAsync(g => g.Key, g => g.ToList());
        }
        */

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
             // Inserción de un solo producto (Se usó para motivos de pruebas)
              
              
        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        
        public async Task AddProductsAsync(List<Product> products)
        {
            _context.Products.AddRange(products); 
            await _context.SaveChangesAsync();
        }


        public async Task RemoveProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            else {
                throw new InvalidOperationException("No existe un producto con ese Id.");
            }
        }

        public async Task MarkAsDefectiveAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.Status = "Defectuoso";  
                _context.Products.Update(product);  
                await _context.SaveChangesAsync(); 
            }
        }

        public async Task ReduceStockAsync(int id, int quantity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                if (product.Status == "Salido del stock")
                {
                    throw new InvalidOperationException("El producto ya ha salido del stock.");
                }

                if (product.InStock >= quantity)
                {
                    product.InStock -= quantity; 
                    if (product.InStock == 0)
                    {
                        product.Status = "Salido del stock";  // Si el stock llega a 0, marcamos como salido del stock
                    }
                    _context.Products.Update(product); 
                    await _context.SaveChangesAsync();  
                }
                else
                {
                    throw new InvalidOperationException("No hay suficiente stock disponible.");
                }
            }
        }

    }
}
