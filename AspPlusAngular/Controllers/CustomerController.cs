using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspPlusAngular.Data;
using AspPlusAngular.Models;
using Microsoft.Extensions.Configuration;

namespace AspPlusAngular.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {

        private readonly AppDbContext appDbContext;

        public CustomerController(AppDbContext app)
        {
            appDbContext = app;
        }


        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(appDbContext.Customers);
        }


        [HttpPost]
        public JsonResult Post(Customer customer)
        {
            customer.Date = DateTime.Now.Date;
            Guid id = Guid.NewGuid();
            string s = id.ToString("N");
            customer.CustomerId = s.Substring(0,8);
            customer.OrdersCount = 0;
            customer.TotalOrderCost = 0;
            appDbContext.Customers.Add(customer);
            appDbContext.SaveChanges();
            return new JsonResult("Added Succsesfully");
        }


    }
}
