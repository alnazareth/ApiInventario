using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Models;
using SistemaInventario.Repositories;

namespace SistemaInventario.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _repository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            await _repository.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        

        [HttpPost("AddProducts")]
        public async Task<ActionResult> AddProducts([FromBody] List<Product> products)
        {
            await _repository.AddProductsAsync(products);
            return Ok(new { message = $"Se agregaron {products.Count} productos " });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveProduct(int id)
        {
            await _repository.RemoveProductAsync(id);
            return NoContent();
        }

        [HttpPut("MarcarDefectuoso/{id}")]
        public async Task<IActionResult> MarkAsDefective(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();  // Si el producto no existe, retorna un 404
            }

            await _repository.MarkAsDefectiveAsync(id); 
            return NoContent(); 
        }

        [HttpPut("SalidaProductos/{id}")]
        public async Task<IActionResult> ReduceStock(int id, [FromBody] int quantity)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(); 
            }

            try
            {
                await _repository.ReduceStockAsync(id, quantity);  
                return NoContent();  
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);  
            }
        }

    }
}
