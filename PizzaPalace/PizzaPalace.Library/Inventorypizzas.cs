using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class Inventorypizzas
    {
        public int Storeid { get; set; }
        public string Pizzaname { get; set; }
        public int Itemamount { get; set; }
        public int Inventpizzasid { get; set; }

        public Pizzas PizzanameNavigation { get; set; }
        public Pizzastore Store { get; set; }
    }
}
