using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService2
{
    public class Order
    {
        public string CustomerName { get;  set; }
        public string CustomerEmail { get;  set; }
        public int OrderId { get; set; }
        public string Address { get; set; }
    }

}

