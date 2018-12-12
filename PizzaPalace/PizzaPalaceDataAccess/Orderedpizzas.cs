using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Orderedpizzas
    {
        public Orderedpizzas()
        {
            Orderdetails = new HashSet<Orderdetails>();
        }

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

        public virtual Pizzas HawaiianNavigation { get; set; }
        public virtual Pizzas MargheritaNavigation { get; set; }
        public virtual Pizzas MeatloverNavigation { get; set; }
        public virtual Pizzas SupremeNavigation { get; set; }
        public virtual ICollection<Orderdetails> Orderdetails { get; set; }
    }
}
