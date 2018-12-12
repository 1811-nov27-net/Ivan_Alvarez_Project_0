using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaPalace.DataAccess
{
    public static class Mapper
    {


        public static Library.Customer Map(Customer customer) => new Library.Customer
        {
            Userid = customer.Userid,
            Username = customer.Username,
            Deflocationid = customer.Deflocationid,
            Haveorder = customer.Haveorder,
            Dateplaced = customer.Dateplaced,
            //Deflocation = Map(customer.Deflocation),
            //History = Map(customer.History).ToList(),
            //Orderdetails = Map(customer.Orderdetails).ToList(),
        };

        public static Customer Map(Library.Customer customer) => new Customer
        {
            Userid = customer.Userid,
            Username = customer.Username,
            Deflocationid = customer.Deflocationid,
            Haveorder = customer.Haveorder,
            Dateplaced = customer.Dateplaced,
           // Deflocation = Map(customer.Deflocation),
           // History = Map(customer.History).ToList(),
           // Orderdetails = Map(customer.Orderdetails).ToList(),
        };

        public static Library.Drinks Map(Drinks drinks) => new Library.Drinks
        {
            Name = drinks.Name,
            Cost = drinks.Cost,
           // Inventorydrinks = Map(drinks.Inventorydrinks).ToList(),
           // OrdereddrinksBluemoonNavigation = Map(drinks.OrdereddrinksBluemoonNavigation).ToList(),
           // OrdereddrinksBriskNavigation = Map(drinks.OrdereddrinksBriskNavigation).ToList(),
          //  OrdereddrinksMerlotNavigation = Map(drinks.OrdereddrinksMerlotNavigation).ToList(),
        //    OrdereddrinksHorchataNavigation = Map(drinks.OrdereddrinksHorchataNavigation).ToList(),
        };

        public static Drinks Map(Library.Drinks drinks) => new Drinks
        {
            Name = drinks.Name,
            Cost = drinks.Cost,
          //  Inventorydrinks = Map(drinks.Inventorydrinks).ToList(),
          //  OrdereddrinksBluemoonNavigation = Map(drinks.OrdereddrinksBluemoonNavigation).ToList(),
         ///   OrdereddrinksBriskNavigation = Map(drinks.OrdereddrinksBriskNavigation).ToList(),
          //  OrdereddrinksMerlotNavigation = Map(drinks.OrdereddrinksMerlotNavigation).ToList(),
          //  OrdereddrinksHorchataNavigation = Map(drinks.OrdereddrinksHorchataNavigation).ToList(),
        };

        public static Library.History Map(History history) => new Library.History
        {
            Historyid = history.Historyid,
            Userid = history.Userid,
            Storeid = history.Storeid,
            Orderid = history.Orderid,
          //  Order = Map(history.Order),
          //  Store = Map(history.Store),
          //  User = Map(history.User),
        };

        public static History Map(Library.History history) => new History
        {
            Historyid = history.Historyid,
            Userid = history.Userid,
            Storeid = history.Storeid,
            Orderid = history.Orderid,
        //    Order = Map(history.Order),
         //   Store = Map(history.Store),
          //  User = Map(history.User),
        };

        public static Library.Inventorydrinks Map(Inventorydrinks inventorydrinks) => new Library.Inventorydrinks
        {
            Storeid = inventorydrinks.Storeid,
            Drinkname = inventorydrinks.Drinkname,
            Itemamount = inventorydrinks.Itemamount,
            Inventdrinkid = inventorydrinks.Inventdrinkid,
         //   DrinknameNavigation = Map(inventorydrinks.DrinknameNavigation),
         ///   Store = Map(inventorydrinks.Store),
        };

        public static Inventorydrinks Map(Library.Inventorydrinks inventorydrinks) => new Inventorydrinks
        {
            Storeid = inventorydrinks.Storeid,
            Drinkname = inventorydrinks.Drinkname,
            Itemamount = inventorydrinks.Itemamount,
            Inventdrinkid = inventorydrinks.Inventdrinkid,
          ///  DrinknameNavigation = Map(inventorydrinks.DrinknameNavigation),
          //  Store = Map(inventorydrinks.Store),
        };

        public static Library.Inventorypizzas Map(Inventorypizzas inventorypizzas) => new Library.Inventorypizzas
        {
            Storeid = inventorypizzas.Storeid,
            Pizzaname = inventorypizzas.Pizzaname,
            Itemamount = inventorypizzas.Itemamount,
            Inventpizzasid = inventorypizzas.Inventpizzasid,
         ///   PizzanameNavigation = Map(inventorypizzas.PizzanameNavigation),
         //   Store = Map(inventorypizzas.Store),
        };

        public static Inventorypizzas Map(Library.Inventorypizzas inventorypizzas) => new Inventorypizzas
        {
            Storeid = inventorypizzas.Storeid,
            Pizzaname = inventorypizzas.Pizzaname,
            Itemamount = inventorypizzas.Itemamount,
            Inventpizzasid = inventorypizzas.Inventpizzasid,
          ///  PizzanameNavigation = Map(inventorypizzas.PizzanameNavigation),
         ///   Store = Map(inventorypizzas.Store),
        };

        public static Library.Inventorysides Map(Inventorysides inventorysides) => new Library.Inventorysides
        {
            Storeid = inventorysides.Storeid,
            Sidename = inventorysides.Sidename,
            Itemamount = inventorysides.Itemamount,
            Inventsidesid = inventorysides.Inventsidesid,
          //  SidenameNavigation = Map(inventorysides.SidenameNavigation),
         //   Store = Map(inventorysides.Store),
        };

        public static Inventorysides Map(Library.Inventorysides inventorysides) => new Inventorysides
        {
            Storeid = inventorysides.Storeid,
            Sidename = inventorysides.Sidename,
            Itemamount = inventorysides.Itemamount,
            Inventsidesid = inventorysides.Inventsidesid,
       ///     SidenameNavigation = Map(inventorysides.SidenameNavigation),
        // /   Store = Map(inventorysides.Store),
        };

        public static Library.Location Map(Location location) => new Library.Location
        {
            Locationid = location.Locationid,
            State = location.State,
            Street = location.Street,
            City = location.City,
        //    Pizzastore = Map(location.Pizzastore),
         //   Customer = Map(location.Customer).ToList(),
         //   Orderdetails = Map(location.Orderdetails).ToList(),
        };

        public static Location Map(Library.Location location) => new Location
        {
            Locationid = location.Locationid,
            Street = location.Street,
            State = location.State,
            City = location.City,
         //   Pizzastore = Map(location.Pizzastore),
          //  Customer = Map(location.Customer).ToList(),
          //  Orderdetails = Map(location.Orderdetails).ToList(),
        };

        public static Library.Orderdetails Map(Orderdetails orderdetails) => new Library.Orderdetails
        {
            Orderid = orderdetails.Orderid,
            Customerid = orderdetails.Customerid,
            Storeid = orderdetails.Storeid,
            Locationid = orderdetails.Locationid,
            Osid = orderdetails.Osid,
            Opid = orderdetails.Opid,
            Odid = orderdetails.Odid,
            Totalcost = orderdetails.Totalcost,
            Dateplaced = orderdetails.Dateplaced,
        //    Customer = Map(orderdetails.Customer),
        //    Location = Map(orderdetails.Location),
         //   Od = Map(orderdetails.Od),
          //  Op = Map(orderdetails.Op),
          //  Os = Map(orderdetails.Os),
          //  Store = Map(orderdetails.Store),
          //  History = Map(orderdetails.History).ToList(),
        };

        public static Orderdetails Map(Library.Orderdetails orderdetails) => new Orderdetails
        {
            Orderid = orderdetails.Orderid,
            Customerid = orderdetails.Customerid,
            Storeid = orderdetails.Storeid,
            Locationid = orderdetails.Locationid,
            Osid = orderdetails.Osid,
            Opid = orderdetails.Opid,
            Odid = orderdetails.Odid,
            Totalcost = orderdetails.Totalcost,
            Dateplaced = orderdetails.Dateplaced,
         //   Customer = Map(orderdetails.Customer),
         //   Location = Map(orderdetails.Location),
         //   Od = Map(orderdetails.Od),
         //   Op = Map(orderdetails.Op),
          //  Os = Map(orderdetails.Os),
          //  Store = Map(orderdetails.Store),
          //  History = Map(orderdetails.History).ToList(),
        };

        public static Library.Ordereddrinks Map(Ordereddrinks ordereddrinks) => new Library.Ordereddrinks
        {
            Ordereddrinksid = ordereddrinks.Ordereddrinksid,
            Brisk = ordereddrinks.Brisk,
            Merlot = ordereddrinks.Merlot,
            Horchata = ordereddrinks.Horchata,
            Bluemoon = ordereddrinks.Bluemoon,
            Briskqty = ordereddrinks.Briskqty,
            Merlotqty = ordereddrinks.Merlotqty,
            Horchataqty = ordereddrinks.Horchataqty,
            Bluemoonqty = ordereddrinks.Bluemoonqty,
            Drinkscost = ordereddrinks.Drinkscost,
     //       BluemoonNavigation = Map(ordereddrinks.BluemoonNavigation),
     //       BriskNavigation = Map(ordereddrinks.BriskNavigation),
     //       MerlotNavigation = Map(ordereddrinks.MerlotNavigation),
     //       HorchataNavigation = Map(ordereddrinks.HorchataNavigation),
      //      Orderdetails = Map(ordereddrinks.Orderdetails).ToList(),
        };

        public static Ordereddrinks Map(Library.Ordereddrinks ordereddrinks) => new Ordereddrinks
        {
            Ordereddrinksid = ordereddrinks.Ordereddrinksid,
            Brisk = ordereddrinks.Brisk,
            Merlot = ordereddrinks.Merlot,
            Horchata = ordereddrinks.Horchata,
            Bluemoon = ordereddrinks.Bluemoon,
            Briskqty = ordereddrinks.Briskqty,
            Merlotqty = ordereddrinks.Merlotqty,
            Horchataqty = ordereddrinks.Horchataqty,
            Bluemoonqty = ordereddrinks.Bluemoonqty,
            Drinkscost = ordereddrinks.Drinkscost,
       //     BluemoonNavigation = Map(ordereddrinks.BluemoonNavigation),
       //     BriskNavigation = Map(ordereddrinks.BriskNavigation),
       //     MerlotNavigation = Map(ordereddrinks.MerlotNavigation),
      ///      HorchataNavigation = Map(ordereddrinks.HorchataNavigation),
         //   Orderdetails = Map(ordereddrinks.Orderdetails).ToList(),
        };

        public static Library.Orderedpizzas Map(Orderedpizzas orderedpizzas) => new Library.Orderedpizzas
        {
            Orderedpizzasid = orderedpizzas.Orderedpizzasid,
            Meatlover = orderedpizzas.Meatlover,
            Supreme = orderedpizzas.Supreme,
            Hawaiian = orderedpizzas.Hawaiian,
            Margherita = orderedpizzas.Margherita,
            Meatloverqty = orderedpizzas.Meatloverqty,
            Supremeqty = orderedpizzas.Supremeqty,
            Hawaiianqty = orderedpizzas.Hawaiianqty,
            Margheritaqty = orderedpizzas.Margheritaqty,
            Pizzascost = orderedpizzas.Pizzascost,
        //    MeatloverNavigation = Map(orderedpizzas.MeatloverNavigation),
       //     SupremeNavigation = Map(orderedpizzas.SupremeNavigation),
         ///   HawaiianNavigation = Map(orderedpizzas.HawaiianNavigation),
         //   MargheritaNavigation = Map(orderedpizzas.MargheritaNavigation),
          //  Orderdetails = Map(orderedpizzas.Orderdetails).ToList(),
        };

        public static Orderedpizzas Map(Library.Orderedpizzas orderedpizzas) => new Orderedpizzas
        {
            Orderedpizzasid = orderedpizzas.Orderedpizzasid,
            Meatlover = orderedpizzas.Meatlover,
            Supreme = orderedpizzas.Supreme,
            Hawaiian = orderedpizzas.Hawaiian,
            Margherita = orderedpizzas.Margherita,
            Meatloverqty = orderedpizzas.Meatloverqty,
            Supremeqty = orderedpizzas.Supremeqty,
            Hawaiianqty = orderedpizzas.Hawaiianqty,
            Margheritaqty = orderedpizzas.Margheritaqty,
            Pizzascost = orderedpizzas.Pizzascost,
        //    MeatloverNavigation = Map(orderedpizzas.MeatloverNavigation),
        //    SupremeNavigation = Map(orderedpizzas.SupremeNavigation),
       //     HawaiianNavigation = Map(orderedpizzas.HawaiianNavigation),
        //    MargheritaNavigation = Map(orderedpizzas.MargheritaNavigation),
       //     Orderdetails = Map(orderedpizzas.Orderdetails).ToList(),
        };

        public static Library.Orderedsides Map(Orderedsides orderedsides) => new Library.Orderedsides
        {
            Orderedsidesid = orderedsides.Orderedsidesid,
            Wings = orderedsides.Wings,
            Ceasarsalad = orderedsides.Ceasarsalad,
            Garlicbread = orderedsides.Garlicbread,
            Alfredopasta = orderedsides.Alfredopasta,
            Wingsqty = orderedsides.Wingsqty,
            Ceasarsaladqty = orderedsides.Ceasarsaladqty,
            Garlicbreadqty = orderedsides.Garlicbreadqty,
            Alfredopastaqty = orderedsides.Alfredopastaqty,
            Sidescost = orderedsides.Sidescost,
         //   WingsNavigation = Map(orderedsides.WingsNavigation),
         //   CeasarsaladNavigation = Map(orderedsides.CeasarsaladNavigation),
         //   GarlicbreadNavigation = Map(orderedsides.GarlicbreadNavigation),
         //   AlfredopastaNavigation = Map(orderedsides.AlfredopastaNavigation),
        //    Orderdetails = Map(orderedsides.Orderdetails).ToList(),
        };

        public static Orderedsides Map(Library.Orderedsides orderedsides) => new Orderedsides
        {
            Orderedsidesid = orderedsides.Orderedsidesid,
            Wings = orderedsides.Wings,
            Ceasarsalad = orderedsides.Ceasarsalad,
            Garlicbread = orderedsides.Garlicbread,
            Alfredopasta = orderedsides.Alfredopasta,
            Wingsqty = orderedsides.Wingsqty,
            Ceasarsaladqty = orderedsides.Ceasarsaladqty,
            Garlicbreadqty = orderedsides.Garlicbreadqty,
            Alfredopastaqty = orderedsides.Alfredopastaqty,
            Sidescost = orderedsides.Sidescost,
         //   WingsNavigation = Map(orderedsides.WingsNavigation),
        //    CeasarsaladNavigation = Map(orderedsides.CeasarsaladNavigation),
        //    GarlicbreadNavigation = Map(orderedsides.GarlicbreadNavigation),
        //    AlfredopastaNavigation = Map(orderedsides.AlfredopastaNavigation),
        //    Orderdetails = Map(orderedsides.Orderdetails).ToList(),
        };

        public static Library.Pizzas Map(Pizzas pizzas) => new Library.Pizzas
        {
            Name = pizzas.Name,
            Cost = pizzas.Cost,
          //  Inventorypizzas = Map(pizzas.Inventorypizzas).ToList(),
          //  OrderedpizzasMeatloverNavigation = Map(pizzas.OrderedpizzasMeatloverNavigation).ToList(),
         //   OrderedpizzasSupremeNavigation = Map(pizzas.OrderedpizzasSupremeNavigation).ToList(),
        //    OrderedpizzasHawaiianNavigation = Map(pizzas.OrderedpizzasHawaiianNavigation).ToList(),
      //      OrderedpizzasMargheritaNavigation = Map(pizzas.OrderedpizzasMargheritaNavigation).ToList(),
        };

        public static Pizzas Map(Library.Pizzas pizzas) => new Pizzas
        {
            Name = pizzas.Name,
            Cost = pizzas.Cost,
        //    Inventorypizzas = Map(pizzas.Inventorypizzas).ToList(),
        //    OrderedpizzasMeatloverNavigation = Map(pizzas.OrderedpizzasMeatloverNavigation).ToList(),
        //    OrderedpizzasSupremeNavigation = Map(pizzas.OrderedpizzasSupremeNavigation).ToList(),
       //     OrderedpizzasHawaiianNavigation = Map(pizzas.OrderedpizzasHawaiianNavigation).ToList(),
       //     OrderedpizzasMargheritaNavigation = Map(pizzas.OrderedpizzasMargheritaNavigation).ToList(),
        };

        public static Library.Sides Map(Sides sides) => new Library.Sides
        {
            Name = sides.Name,
            Cost = sides.Cost,
          //  Inventorysides = Map(sides.Inventorysides).ToList(),
          //  OrderedsidesWingsNavigation = Map(sides.OrderedsidesWingsNavigation).ToList(),
        //    OrderedsidesAlfredopastaNavigation = Map(sides.OrderedsidesAlfredopastaNavigation).ToList(),
        //    OrderedsidesCeasarsaladNavigation = Map(sides.OrderedsidesCeasarsaladNavigation).ToList(),
       //     OrderedsidesGarlicbreadNavigation = Map(sides.OrderedsidesGarlicbreadNavigation).ToList(),
        };

        public static Sides Map(Library.Sides sides) => new Sides
        {
            Name = sides.Name,
            Cost = sides.Cost,
          //  Inventorysides = Map(sides.Inventorysides).ToList(),
          //  OrderedsidesWingsNavigation = Map(sides.OrderedsidesWingsNavigation).ToList(),
          //  OrderedsidesAlfredopastaNavigation = Map(sides.OrderedsidesAlfredopastaNavigation).ToList(),
          //  OrderedsidesCeasarsaladNavigation = Map(sides.OrderedsidesCeasarsaladNavigation).ToList(),
          //  OrderedsidesGarlicbreadNavigation = Map(sides.OrderedsidesGarlicbreadNavigation).ToList(),
        };

        public static Library.Pizzastore Map(Pizzastore pizzastore) => new Library.Pizzastore
        {
            Storeid = pizzastore.Storeid,
            Name = pizzastore.Name,
            Locationid = pizzastore.Locationid,
         //   Location = Map(pizzastore.Location),
          //  History = Map(pizzastore.History).ToList(),
         //   Inventorysides = Map(pizzastore.Inventorysides).ToList(),
        //    Inventorypizzas = Map(pizzastore.Inventorypizzas).ToList(),
        //    Inventorydrinks = Map(pizzastore.Inventorydrinks).ToList(),
          //  Orderdetails = Map(pizzastore.Orderdetails).ToList(),
        };

        public static Pizzastore Map(Library.Pizzastore pizzastore) => new Pizzastore
        {
            Storeid = pizzastore.Storeid,
            Name = pizzastore.Name,
            Locationid = pizzastore.Locationid,
          //  Location = Map(pizzastore.Location),
          //  History = Map(pizzastore.History).ToList(),
          //  Inventorysides = Map(pizzastore.Inventorysides).ToList(),
          //  Inventorypizzas = Map(pizzastore.Inventorypizzas).ToList(),
         //   Inventorydrinks = Map(pizzastore.Inventorydrinks).ToList(),
          //  Orderdetails = Map(pizzastore.Orderdetails).ToList(),
        };

        public static IEnumerable<Library.History> Map(IEnumerable<History> histories) => histories.Select(Map);
        public static IEnumerable<History> Map(IEnumerable<Library.History> histories) => histories.Select(Map);

        public static IEnumerable<Library.Orderdetails> Map(IEnumerable<Orderdetails> orderdetails) => orderdetails.Select(Map);
        public static IEnumerable<Orderdetails> Map(IEnumerable<Library.Orderdetails> orderdetails) => orderdetails.Select(Map);

        public static IEnumerable<Library.Inventorydrinks> Map(IEnumerable<Inventorydrinks> inventorydrinks) => inventorydrinks.Select(Map);
        public static IEnumerable<Inventorydrinks> Map(IEnumerable<Library.Inventorydrinks> inventorydrinks) => inventorydrinks.Select(Map);

        public static IEnumerable<Library.Inventorypizzas> Map(IEnumerable<Inventorypizzas> inventorypizzas) => inventorypizzas.Select(Map);
        public static IEnumerable<Inventorypizzas> Map(IEnumerable<Library.Inventorypizzas> inventorypizzas) => inventorypizzas.Select(Map);

        public static IEnumerable<Library.Inventorysides> Map(IEnumerable<Inventorysides> inventorysides) => inventorysides.Select(Map);
        public static IEnumerable<Inventorysides> Map(IEnumerable<Library.Inventorysides> inventorysides) => inventorysides.Select(Map);

        public static IEnumerable<Library.Ordereddrinks> Map(IEnumerable<Ordereddrinks> ordereddrinks) => ordereddrinks.Select(Map);
        public static IEnumerable<Ordereddrinks> Map(IEnumerable<Library.Ordereddrinks> ordereddrinks) => ordereddrinks.Select(Map);

        public static IEnumerable<Library.Orderedpizzas> Map(IEnumerable<Orderedpizzas> orderedpizzas) => orderedpizzas.Select(Map);
        public static IEnumerable<Orderedpizzas> Map(IEnumerable<Library.Orderedpizzas> orderedpizzas) => orderedpizzas.Select(Map);

        public static IEnumerable<Library.Orderedsides> Map(IEnumerable<Orderedsides> orderedsides) => orderedsides.Select(Map);
        public static IEnumerable<Orderedsides> Map(IEnumerable<Library.Orderedsides> orderedsides) => orderedsides.Select(Map);

        public static IEnumerable<Library.Customer> Map(IEnumerable<Customer> customers) => customers.Select(Map);
        public static IEnumerable<Customer> Map(IEnumerable<Library.Customer> customers) => customers.Select(Map);

        public static IEnumerable<Library.Drinks> Map(IEnumerable<Drinks> drinks) => drinks.Select(Map);
        public static IEnumerable<Drinks> Map(IEnumerable<Library.Drinks> drinks) => drinks.Select(Map);

        public static IEnumerable<Library.Pizzas> Map(IEnumerable<Pizzas> pizzas) => pizzas.Select(Map);
        public static IEnumerable<Pizzas> Map(IEnumerable<Library.Pizzas> pizzas) => pizzas.Select(Map);

        public static IEnumerable<Library.Sides> Map(IEnumerable<Sides> sides) => sides.Select(Map);
        public static IEnumerable<Sides> Map(IEnumerable<Library.Sides> sides) => sides.Select(Map);

        public static IEnumerable<Library.Location> Map(IEnumerable<Location> locations) => locations.Select(Map);
        public static IEnumerable<Location> Map(IEnumerable<Library.Location> locations) => locations.Select(Map);

        public static IEnumerable<Library.Pizzastore> Map(IEnumerable<Pizzastore> pizzastores) => pizzastores.Select(Map);
        public static IEnumerable<Pizzastore> Map(IEnumerable<Library.Pizzastore> pizzastores) => pizzastores.Select(Map);

    }
}
