using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Orderedsides
    {
        public Orderedsides()
        {
            Orderdetails = new HashSet<Orderdetails>();
        }

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

        public virtual Sides AlfredopastaNavigation { get; set; }
        public virtual Sides CeasarsaladNavigation { get; set; }
        public virtual Sides GarlicbreadNavigation { get; set; }
        public virtual Sides WingsNavigation { get; set; }
        public virtual ICollection<Orderdetails> Orderdetails { get; set; }
    }
}
