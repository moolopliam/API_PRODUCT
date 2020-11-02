using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        private readonly SHOPContext _shopContext = new SHOPContext();
        private readonly IHostingEnvironment _environment;

        public ProductController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

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
            var result = (from prodcut in _shopContext.Products.Where(a => a.ProductCode == id).ToList()
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
        public async Task<IActionResult> Post([FromForm] ProductReq value)
        {
            try
            {
                var rename = "";
                if (value.File != null)
                {
                    if (value.File.ContentType.Split("/")[0] == "image")
                    {
                        _environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                        var uploads = Path.Combine(_environment.WebRootPath, "images");

                        if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                        if (value.File.Length > 0)
                        {
                            rename = Guid.NewGuid() + "." + value.File.ContentType.Split("/")[1];
                            var fileStream = new FileStream(Path.Combine(uploads, rename), FileMode.Create);
                            await value.File.CopyToAsync(fileStream);

                        }
                    }
                    else
                    {
                        return Ok(new { status = 0, mgs = "Support image files." });

                    }
                }

                await _shopContext.Products.AddAsync(new Products()
                {
                    ProductName = value.ProductName,
                    BuyPrice = value.BuyPrice,
                    SellPrice = value.SellPrice,
                    CategoryCode = value.CategoryCode,
                    Img = rename == "" ? null : rename
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

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/png")
                {
                    _environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    var uploads = Path.Combine(_environment.WebRootPath, "images");

                    if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                    if (file.Length > 0)
                    {

                        var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create);
                        await file.CopyToAsync(fileStream);

                    }

                    return Ok(new { status = 1, mgs = "ok" });
                }
                else
                {
                    return Ok(new { status = 0, mgs = "Support png jpeg files." });

                }

            }
            catch (Exception e)
            {
                return BadRequest(new { status = 0, mgs = e.Message });
            }
        }



        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] ProductReq value)
        {
            try
            {

                if (await _shopContext.Products.AsNoTracking().FirstOrDefaultAsync(a => a.ProductCode == id) != null)
                {
                    var rename = "";
                    if (value.File != null)
                    {
                        if (value.File.ContentType.Split("/")[0] == "image")
                        {
                            _environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                            var uploads = Path.Combine(_environment.WebRootPath, "images");

                            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                            if (value.File.Length > 0)
                            {
                                rename = Guid.NewGuid() + "." + value.File.ContentType.Split("/")[1];
                                var fileStream = new FileStream(Path.Combine(uploads, rename), FileMode.Create);
                                await value.File.CopyToAsync(fileStream);

                            }
                        }
                        else
                        {
                            return Ok(new { status = 0, mgs = "Support image files." });

                        }
                    }

                    var data = new Products()
                    {
                        ProductCode = id,
                        ProductName = value.ProductName,
                        SellPrice = value.SellPrice,
                        BuyPrice = value.BuyPrice,
                        Img = rename == "" ? null : rename,
                        CategoryCode = value.CategoryCode

                    };
                    _shopContext.Entry(data).State = EntityState.Modified;
                    await _shopContext.SaveChangesAsync();

                    return Ok(new { status = 0, mgs = "ok " });
                }

                return Ok(new { status = 0, mgs = "No data " });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = 0, mgs = e.Message });
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _shopContext.Products.AsNoTracking().FirstOrDefaultAsync(a => a.ProductCode == id);
                if (data != null)
                {
                    _shopContext.Products.Remove(data);
                    await _shopContext.SaveChangesAsync();
                    return Ok(new { status = 0, mgs = "ok " });
                }

                return Ok(new { status = 0, mgs = "No data " });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = 0, mgs = e.Message });

            }
        }
    }
}
