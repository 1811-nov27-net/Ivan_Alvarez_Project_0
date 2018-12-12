using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Ordereddrinks
    {
        public Ordereddrinks()
        {
            Orderdetails = new HashSet<Orderdetails>();
        }

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

        public virtual Drinks BluemoonNavigation { get; set; }
        public virtual Drinks BriskNavigation { get; set; }
        public virtual Drinks HorchataNavigation { get; set; }
        public virtual Drinks MerlotNavigation { get; set; }
        public virtual ICollection<Orderdetails> Orderdetails { get; set; }
    }
}
