using SistemaInventario.Models;

namespace SistemaInventario.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        //  Task<Dictionary<string, List<Product>>> GetAllProductsAsync(); esto devuelve categorizado por estado  (Se usó para motivos de pruebas)
        Task<Product> GetProductByIdAsync(int id);
         Task AddProductAsync(Product product); //agregar un solo producto
        Task AddProductsAsync(List<Product> products); // agregar varios productos (Se usó para motivos de pruebas)
        Task RemoveProductAsync(int id);  // eliminar producto
        Task MarkAsDefectiveAsync(int id);    // marcar como defectuoso

        Task ReduceStockAsync(int id, int quantity); // gestionar el stock

    }
}
