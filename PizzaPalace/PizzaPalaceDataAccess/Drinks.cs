using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Drinks
    {
        public Drinks()
        {
            Inventorydrinks = new HashSet<Inventorydrinks>();
            OrdereddrinksBluemoonNavigation = new HashSet<Ordereddrinks>();
            OrdereddrinksBriskNavigation = new HashSet<Ordereddrinks>();
            OrdereddrinksHorchataNavigation = new HashSet<Ordereddrinks>();
            OrdereddrinksMerlotNavigation = new HashSet<Ordereddrinks>();
        }

        public string Name { get; set; }
        public double Cost { get; set; }

        public virtual ICollection<Inventorydrinks> Inventorydrinks { get; set; }
        public virtual ICollection<Ordereddrinks> OrdereddrinksBluemoonNavigation { get; set; }
        public virtual ICollection<Ordereddrinks> OrdereddrinksBriskNavigation { get; set; }
        public virtual ICollection<Ordereddrinks> OrdereddrinksHorchataNavigation { get; set; }
        public virtual ICollection<Ordereddrinks> OrdereddrinksMerlotNavigation { get; set; }
    }
}
