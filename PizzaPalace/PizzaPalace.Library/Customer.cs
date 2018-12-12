using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public class Customer
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public int Deflocationid { get; set; }
        public bool Haveorder { get; set; }
        public DateTime? Dateplaced { get; set; }

        public Location Deflocation { get; set; }
        public List<History> History { get; set; }
        public List<Orderdetails> Orderdetails { get; set; }

        public Customer()
        {

        }

        

        public Customer(string ggg)
        {

            Username = ggg;
        }
    }
}
