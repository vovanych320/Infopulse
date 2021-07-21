using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspPlusAngular.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public double TotalOrderCost { get; set; }

        public uint OrdersCount { get; set; }

        public DateTime Date { get; set; }
    }
}
