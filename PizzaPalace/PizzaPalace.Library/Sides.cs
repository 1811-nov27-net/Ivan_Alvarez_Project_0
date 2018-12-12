using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class Sides
    {
        public string Name { get; set; }
        public double Cost { get; set; }

        public List<Inventorysides> Inventorysides { get; set; }
        public List<Orderedsides> OrderedsidesAlfredopastaNavigation { get; set; }
        public List<Orderedsides> OrderedsidesCeasarsaladNavigation { get; set; }
        public List<Orderedsides> OrderedsidesGarlicbreadNavigation { get; set; }
        public List<Orderedsides> OrderedsidesWingsNavigation { get; set; }
    }
}
