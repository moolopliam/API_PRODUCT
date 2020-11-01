using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        private readonly SHOPContext _shopContext = new SHOPContext();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = (from prodcut in _shopContext.Products.ToList()
                              join category in _shopContext.Category
                                  on prodcut.CategoryCode equals category.CategoryCode into data
                              from v in data.DefaultIfEmpty()
                              select new
                              {
                                  Name = prodcut.ProductCode,
                                  prodcut.ProductName,
                                  prodcut.Img,
                                  prodcut.BuyPrice,
                                  prodcut.SellPrice,
                                  CategoryName = v == null ? null : v.CategoryName
                              });
                return Ok(new
                {
                    user = new
                    {
                        name = "tae",
                        lateNmae = "sorot",
                        date = DateTime.Now
                    },
                    order = result
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("GetDetail")]
        public IActionResult Get(int id)
        {
            var result  = (from prodcut in _shopContext.Products.Where (a => a.ProductCode == id).ToList()
                join category in _shopContext.Category
                    on prodcut.CategoryCode equals category.CategoryCode into data
                from v in data.DefaultIfEmpty()
                select new
                {
                    Name = prodcut.ProductCode,
                    prodcut.ProductName,
                    prodcut.Img,
                    prodcut.BuyPrice,
                    prodcut.SellPrice,
                    CategoryName = v == null ? null : v.CategoryName
                });
            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductReq value)
        {
            try
            {
                 await _shopContext.Products.AddAsync(new Products()
                 {
                     ProductName = value.ProductName,
                     BuyPrice = value.BuyPrice,
                     SellPrice = value.SellPrice,
                     CategoryCode = value.CategoryCode
                 });
                await _shopContext.SaveChangesAsync();
                return Ok(new
                {
                    status = 1,
                    msg = "ok"
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
