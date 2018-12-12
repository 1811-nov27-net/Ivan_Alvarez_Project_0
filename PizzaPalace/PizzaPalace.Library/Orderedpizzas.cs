using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class Orderedpizzas
    {
        public int Orderedpizzasid { get; set; }
        public string Meatlover { get; set; }
        public string Supreme { get; set; }
        public string Hawaiian { get; set; }
        public string Margherita { get; set; }
        public int Meatloverqty { get; set; }
        public int Supremeqty { get; set; }
        public int Hawaiianqty { get; set; }
        public int Margheritaqty { get; set; }
        public double Pizzascost { get; set; }

        public Pizzas HawaiianNavigation { get; set; }
        public Pizzas MargheritaNavigation { get; set; }
        public Pizzas MeatloverNavigation { get; set; }
        public Pizzas SupremeNavigation { get; set; }
        public List<Orderdetails> Orderdetails { get; set; }

        public Orderedpizzas() { }
    }
}
