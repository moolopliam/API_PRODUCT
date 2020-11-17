using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly SHOPContext _shopContext = new SHOPContext();

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _shopContext.Category.ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(new { status = 0, mgss = e.Message });
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
