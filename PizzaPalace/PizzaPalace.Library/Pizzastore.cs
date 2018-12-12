using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class Pizzastore
    {
        public int Storeid { get; set; }
        public string Name { get; set; }
        public int Locationid { get; set; }

        public Location Location { get; set; }
        public List<History> History { get; set; }
        public List<Inventorydrinks> Inventorydrinks { get; set; }
        public List<Inventorypizzas> Inventorypizzas { get; set; }
        public List<Inventorysides> Inventorysides { get; set; }
        public List<Orderdetails> Orderdetails { get; set; }

        public Pizzastore()
            {}

    }
}
