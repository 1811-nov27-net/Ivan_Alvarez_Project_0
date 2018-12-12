using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class Drinks
    {
        public string Name { get; set; }
        public double Cost { get; set; }

        public List<Inventorydrinks> Inventorydrinks { get; set; }
        public List<Ordereddrinks> OrdereddrinksBluemoonNavigation { get; set; }
        public List<Ordereddrinks> OrdereddrinksBriskNavigation { get; set; }
        public List<Ordereddrinks> OrdereddrinksHorchataNavigation { get; set; }
        public List<Ordereddrinks> OrdereddrinksMerlotNavigation { get; set; }
    }
}
