using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspPlusAngular.Models
{
    public class Product
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductCategory { get; set; }

        public string ProductSize { get; set; }

        public uint Quantity { get; set; }

        public double Price { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
