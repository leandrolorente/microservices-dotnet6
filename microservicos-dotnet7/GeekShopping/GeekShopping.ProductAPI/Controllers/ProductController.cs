using GeekShopping.ProductAPI.Data.DTO;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository repository) // injecao de dependencia 
        {
             _productRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<ProductDto>> FindById(long id)
        {
            var product =  await _productRepository.FindById(id);
            if(product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<ProductDto>> FindByName(string name)
        {
            var product = await _productRepository.FindByName(name);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> FindAll()
        {
            var products =  await _productRepository.FindAll();
            return Ok(products);
        }
    }
}
