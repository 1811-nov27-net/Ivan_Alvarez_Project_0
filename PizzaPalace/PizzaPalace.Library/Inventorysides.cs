using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class Inventorysides
    {

        public int Storeid { get; set; }
        public string Sidename { get; set; }
        public int Itemamount { get; set; }
        public int Inventsidesid { get; set; }

        public Sides SidenameNavigation { get; set; }
        public Pizzastore Store { get; set; }
    }
}
