using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestTask.Models;

namespace TestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        readonly IRepository _repository;
        public ShopController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Shop> Get()
        {
            return _repository.GetShops();
        }

        [HttpGet("{id}")]
        public Shop Get(int id)
        {
            return _repository.GetShop(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Shop value)
        {
            _repository.CreateShop(value);
            return Ok(new { Message = $"Shop {value.Id} added." });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Shop value)
        {
            _repository.UpdateShop(value);
            return Ok(new { Message = $"Shop {value.Id} edited." });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.DeleteShop(id);
            return Ok(new { Message = $"Shop {id} deleted." });
        }
    }
}
