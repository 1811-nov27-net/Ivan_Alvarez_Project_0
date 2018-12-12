using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Sides
    {
        public Sides()
        {
            Inventorysides = new HashSet<Inventorysides>();
            OrderedsidesAlfredopastaNavigation = new HashSet<Orderedsides>();
            OrderedsidesCeasarsaladNavigation = new HashSet<Orderedsides>();
            OrderedsidesGarlicbreadNavigation = new HashSet<Orderedsides>();
            OrderedsidesWingsNavigation = new HashSet<Orderedsides>();
        }

        public string Name { get; set; }
        public double Cost { get; set; }

        public virtual ICollection<Inventorysides> Inventorysides { get; set; }
        public virtual ICollection<Orderedsides> OrderedsidesAlfredopastaNavigation { get; set; }
        public virtual ICollection<Orderedsides> OrderedsidesCeasarsaladNavigation { get; set; }
        public virtual ICollection<Orderedsides> OrderedsidesGarlicbreadNavigation { get; set; }
        public virtual ICollection<Orderedsides> OrderedsidesWingsNavigation { get; set; }
    }
}
