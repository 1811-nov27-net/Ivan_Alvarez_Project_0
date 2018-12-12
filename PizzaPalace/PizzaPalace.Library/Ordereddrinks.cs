using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class Ordereddrinks
    {
        public int Ordereddrinksid { get; set; }
        public string Brisk { get; set; }
        public string Merlot { get; set; }
        public string Horchata { get; set; }
        public string Bluemoon { get; set; }
        public int Briskqty { get; set; }
        public int Merlotqty { get; set; }
        public int Horchataqty { get; set; }
        public int Bluemoonqty { get; set; }
        public double Drinkscost { get; set; }

        public Drinks BluemoonNavigation { get; set; }
        public Drinks BriskNavigation { get; set; }
        public Drinks HorchataNavigation { get; set; }
        public Drinks MerlotNavigation { get; set; }
        public List<Orderdetails> Orderdetails { get; set; }
    }
}
