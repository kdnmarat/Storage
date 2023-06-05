using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageAPI.Models;
using StorageAPI.Services;

namespace StorageAPI.Controllers
{
    [Route("StorageAPI/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IStorageService _storageService;
        public ProductsController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _storageService.GetProductsAsync();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProduct(uint id)
        {
            var product = await _storageService.GetProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateProduct(Product productToCreate)
        {
            var product = await _storageService.CreateProductAsync(productToCreate);
            if (product == null)
            {
                return BadRequest();
            }
            return Ok(product);
        }

        [HttpPost]
        [Route("[action]/{id}")]
        public async Task<IActionResult> EditProduct(uint id, Product productToCreate)
        {
            var product = await _storageService.EditProductAsync(id, productToCreate);
            if (product == null)
            {
                return BadRequest();
            }
            return Ok(product);
        }
    }
}
