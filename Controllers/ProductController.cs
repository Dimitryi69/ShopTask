using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        readonly IRepository _repository;
        public ProductController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repository.GetProducts();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _repository.GetProduct(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            _repository.CreateProduct(value);
            return Ok(new { Message = $"Product {value.Id} created." });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product value)
        {
            _repository.UpdateProduct(value);
            return Ok(new { Message = $"Product {id} edited." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.DeleteProduct(id);
            return Ok(new { Message = $"Product {id} deleted." });
        }
    }
}
