using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class Location
    {

        public int Locationid { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public  Pizzastore Pizzastore { get; set; }
        public  List<Customer> Customer { get; set; }
        public  List<Orderdetails> Orderdetails { get; set; }

        public void Displaylocation()
        {
            Console.WriteLine($"{Street}, {City}, {State}");
        }

        
    }
}
