using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class History
    {
        public int Historyid { get; set; }
        public int Userid { get; set; }
        public int Storeid { get; set; }
        public int Orderid { get; set; }

        public  Orderdetails Order { get; set; }
        public  Pizzastore Store { get; set; }
        public  Customer User { get; set; }
    }
}
