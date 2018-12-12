using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class Pizzas
    {
        public string Name { get; set; }
        public double Cost { get; set; }

        public List<Inventorypizzas> Inventorypizzas { get; set; }
        public List<Orderedpizzas> OrderedpizzasHawaiianNavigation { get; set; }
        public List<Orderedpizzas> OrderedpizzasMargheritaNavigation { get; set; }
        public List<Orderedpizzas> OrderedpizzasMeatloverNavigation { get; set; }
        public List<Orderedpizzas> OrderedpizzasSupremeNavigation { get; set; }
    }
}
