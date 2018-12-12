using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Pizzas
    {
        public Pizzas()
        {
            Inventorypizzas = new HashSet<Inventorypizzas>();
            OrderedpizzasHawaiianNavigation = new HashSet<Orderedpizzas>();
            OrderedpizzasMargheritaNavigation = new HashSet<Orderedpizzas>();
            OrderedpizzasMeatloverNavigation = new HashSet<Orderedpizzas>();
            OrderedpizzasSupremeNavigation = new HashSet<Orderedpizzas>();
        }

        public string Name { get; set; }
        public double Cost { get; set; }

        public virtual ICollection<Inventorypizzas> Inventorypizzas { get; set; }
        public virtual ICollection<Orderedpizzas> OrderedpizzasHawaiianNavigation { get; set; }
        public virtual ICollection<Orderedpizzas> OrderedpizzasMargheritaNavigation { get; set; }
        public virtual ICollection<Orderedpizzas> OrderedpizzasMeatloverNavigation { get; set; }
        public virtual ICollection<Orderedpizzas> OrderedpizzasSupremeNavigation { get; set; }
    }
}
