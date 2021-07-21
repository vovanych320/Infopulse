using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspPlusAngular.Models
{
    public class Order
    {
        [Required]
        public string OrderId { get; set; }

        public  string CustomerName { get; set; }

        public  string CustomerAdress { get; set; }

        public  double TotalCost { get; set; }

        public  string OrderStatus { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderComment { get; set; }

        public IList<Product> Products { get; set; }
    }
}
