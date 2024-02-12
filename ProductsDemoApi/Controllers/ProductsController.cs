using ProductsDemoApi.Models;
using ProductsDemoApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ProductsDemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IDataRepository<Product> _dataRepository;

        public ProductsController(ILogger<ProductsController> logger, IDataRepository<Product> dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _dataRepository.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public Product? Get(int id)
        {
            return _dataRepository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                _dataRepository.Save(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _dataRepository.Delete(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
