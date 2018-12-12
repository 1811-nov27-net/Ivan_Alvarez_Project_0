using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class Orderdetails
    {
        public int Orderid { get; set; }
        public int Customerid { get; set; }
        public int Storeid { get; set; }
        public int Locationid { get; set; }
        public int Osid { get; set; }
        public int Odid { get; set; }
        public int Opid { get; set; }
        public double Totalcost { get; set; }
        public DateTime Dateplaced { get; set; }

        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public Ordereddrinks Od { get; set; }
        public Orderedpizzas Op { get; set; }
        public Orderedsides Os { get; set; }
        public Pizzastore Store { get; set; }
        public List<History> History { get; set; }


        public Orderdetails()
        {

        }
        // public void Addorder ()

    }
}