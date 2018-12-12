using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class Orderedsides
    {
        public int Orderedsidesid { get; set; }
        public string Wings { get; set; }
        public string Ceasarsalad { get; set; }
        public string Garlicbread { get; set; }
        public string Alfredopasta { get; set; }
        public int Wingsqty { get; set; }
        public int Ceasarsaladqty { get; set; }
        public int Garlicbreadqty { get; set; }
        public int Alfredopastaqty { get; set; }
        public double Sidescost { get; set; }

        public Sides AlfredopastaNavigation { get; set; }
        public Sides CeasarsaladNavigation { get; set; }
        public Sides GarlicbreadNavigation { get; set; }
        public Sides WingsNavigation { get; set; }
        public List<Orderdetails> Orderdetails { get; set; }
    }
}
