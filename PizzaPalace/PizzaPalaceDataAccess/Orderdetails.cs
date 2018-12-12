using System;
using System.Collections.Generic;

namespace PizzaPalace.DataAccess
{
    public partial class Orderdetails
    {
        public Orderdetails()
        {
            History = new HashSet<History>();
        }

        public int Orderid { get; set; }
        public int Customerid { get; set; }
        public int Storeid { get; set; }
        public int Locationid { get; set; }
        public int Osid { get; set; }
        public int Odid { get; set; }
        public int Opid { get; set; }
        public double Totalcost { get; set; }
        public DateTime Dateplaced { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Location Location { get; set; }
        public virtual Ordereddrinks Od { get; set; }
        public virtual Orderedpizzas Op { get; set; }
        public virtual Orderedsides Os { get; set; }
        public virtual Pizzastore Store { get; set; }
        public virtual ICollection<History> History { get; set; }
    }
}
