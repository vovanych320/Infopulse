using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPlusAngular.Data;
using AspPlusAngular.Models;

namespace AspPlusAngular.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {

        private readonly AppDbContext appDbContext;

        public OrderController(AppDbContext app)
        {
            appDbContext = app;
        }


        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(appDbContext.Orders);
        }


        [HttpPost]
        public JsonResult Post(Order order)
        {
            Guid id = Guid.NewGuid();
            string s = id.ToString("N");

            order.OrderId = s.Substring(0, 8);
            order.OrderDate = DateTime.Now.Date;
            order.TotalCost = 0;

            appDbContext.Orders.Add(order);
            appDbContext.SaveChanges();
            return new JsonResult("Added Succsesfully");
        }


        //[Route("AddProductToOrder")]
        //public JsonResult AddProduct(Order order, Product product)
        //{
        //    appDbContext.Orders.FirstOrDefault(x => x.OrderId == order.OrderId).Products.Add(product);
        //    Order_Products orderProducts = new Order_Products
        //    {
        //        Id = Guid.NewGuid(),
        //        Order = order,
        //        OrderId = order.OrderId,
        //        Product = product,
        //        ProductId = product.ProductId
        //    };
        //    appDbContext.OrderProducts.Add(orderProducts);
        //    appDbContext.SaveChanges();

        //    return new JsonResult("Added");
        //}

    }
}
