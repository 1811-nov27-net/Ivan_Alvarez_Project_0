using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaPalace.Library
{
    public interface IPizzaRepository
    {
        IEnumerable<History> Gethistory();
        IEnumerable<Orderdetails> Getorders();
        IEnumerable<Customer> Getcustomers();
        IEnumerable<Pizzastore> Getpizzastores();
        IEnumerable<Location> Getlocations();
        IEnumerable<Orderedpizzas> Getopids();

        void Addlocation(Location local);
        void Addorder(Orderdetails order);
        void Addpizzaorder(Orderedpizzas pizzas);
        void Addtohistory(History history);
        Library.Location Grablocation(int localid);
        Library.Pizzastore Grabstore(int storeid);
        Library.Location Grablocationbystreet(string street);
        Library.Orderdetails Graborder(int orderid);
        Library.Customer Grabcustomerbyid(int userid);
        Library.Customer Grabcustomer(string username);


        void Save();
       // void Add
    }
}
