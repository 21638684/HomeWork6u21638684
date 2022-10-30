using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6_v2.Models
{
    public class OrdersViewModel
    {
            public int OrderID { get; set; }
            public product ProdName { get; set; }
            public decimal Price { get; set; }
            public DateTime Date { get; set; }
            public string Category { get; set; }
            public int Quantity { get; set; }
            public decimal Total { get; set; }


    }
}