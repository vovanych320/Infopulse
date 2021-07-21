using AspPlusAngular.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AspPlusAngular.Models;

namespace AspPlusAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext appDbContext;

        public ProductController(AppDbContext app)
        {
            appDbContext = app;
        }


        [HttpGet]
        public JsonResult Get()
        {

            return new JsonResult(appDbContext.Products);
        }


        [HttpPost]
        public JsonResult Post(Product product)
        {
            Guid id = Guid.NewGuid();
            string s = id.ToString("N");

            product.Date = DateTime.Now.Date;
            product.ProductId = s.Substring(0, 8);
            appDbContext.Products.Add(product);
            appDbContext.SaveChanges();

            return new JsonResult("Good");
        }


        [HttpDelete]
        public JsonResult Delete(Product product)
        {
            appDbContext.Products.Attach(product);
            appDbContext.Products.Remove(product);
            appDbContext.SaveChanges();
            return new JsonResult("Good");
        }


    }
}
