using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspPlusAngular.Models
{
    public class Order_Products
    {
        public Guid Id { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}
