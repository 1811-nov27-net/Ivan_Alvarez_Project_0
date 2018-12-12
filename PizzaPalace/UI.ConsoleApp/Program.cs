using System;
using PPDA = PizzaPalace.DataAccess;
using Microsoft.EntityFrameworkCore;
using PizzaPalace.Library;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
namespace UI.ConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PPDA.PizzaDBContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.Connectionstring); 

            var options = optionsBuilder.Options;
            var dbContext = new PPDA.PizzaDBContext(options);
            IPizzaRepository PizzaRepository = new PPDA.PizzaRepository(dbContext);



            Console.WriteLine("Customer(C or c) or Employee(E or e)?:");
            var core = Console.ReadLine();
            if(core == "C" || core == "c")
            {
                Console.WriteLine("What is your username?:");
                var custname = Console.ReadLine();

                var custuser = new Customer();
                var custlist = PizzaRepository.Getcustomers().ToList();     //grabs customers
                for(var i = 0; i < custlist.Count(); i++ )
                {
                    //throw excpetion
                   if(custname == custlist[i].Username)
                    {
                        custuser = custlist[i];
                    }
                    else
                    {
                        //throw exception
                    }
                }
                custuser.Deflocation = PizzaRepository.Grablocation(custuser.Deflocationid);

                Console.WriteLine("Would you like to place an order(O or o):");
                Console.WriteLine("Would you like to display your history(S or s):");
                var custinput = Console.ReadLine();
                if (custinput == "O" || custinput == "o")
                {
                    var neworder = new Orderdetails();                    //new order
                    var local2 = new Location();

                    neworder.Customerid = custuser.Userid;                  //custid for order
                    Console.WriteLine("Use default location(D or d):");
                    Console.WriteLine("New location?(N or n):");
                    var localinput = Console.ReadLine();
                    if (localinput == "D" || localinput == "d")
                    {
                        neworder.Locationid = custuser.Deflocationid;       // localid for order
                        local2 = PizzaRepository.Grablocation(neworder.Locationid);
                    }
                    else
                    {
                        var newlocal = new Location();
                        Console.WriteLine("Enter street:");
                        var newstreet = Console.ReadLine();
                        Console.WriteLine("Enter City");
                        var newcity = Console.ReadLine();
                        Console.WriteLine("Enter State");
                        var newstate = Console.ReadLine();
                        newlocal.Street = newstreet;
                        newlocal.State = newstate;
                        newlocal.City = newcity;

                        PizzaRepository.Addlocation(newlocal);
                        PizzaRepository.Save();                         //new local
                        local2 = PizzaRepository.Getlocations().Last();

                        neworder.Locationid = local2.Locationid;        //localid fro order
                    }
                    Console.WriteLine("Which Store?");
                    Console.WriteLine("Pizza Palace North(N or n):");
                    Console.WriteLine("Pizza Palace Central(C or c):");
                    var storeinput = Console.ReadLine();

                    var storelist = PizzaRepository.Getpizzastores().ToList();
                    var pizzastore = new Pizzastore();
                    var ppinput = "";
                    if (storeinput == "N" || storeinput == "n")
                    {
                        ppinput = "Pizza Palace North";
                        for (var i = 0; i < storelist.Count(); i++)
                        {
                            if (ppinput == storelist[i].Name)
                            {
                                pizzastore = storelist[i];
                            }
                        }

                    }
                    else
                    {
                        ppinput = "Pizza Palace Central";
                        for (var i = 0; i < storelist.Count(); i++)
                        {
                            if (ppinput == storelist[i].Name)
                            {
                                pizzastore = storelist[i];
                            }
                        }
                    }
                    neworder.Storeid = pizzastore.Storeid;          //store id for order

                    Console.WriteLine("How many pizzas would you like Pizzas($6.75 each)(less than 12):");
                    int pizzacount = Int32.Parse(Console.ReadLine());
                    while (pizzacount > 12 || pizzacount < 1)
                    {
                        Console.WriteLine("Quit messing, how many would you really like:");
                        pizzacount = Int32.Parse(Console.ReadLine());
                    }

                    var orderedpizzas = new Orderedpizzas();
                    orderedpizzas.Pizzascost = pizzacount * 6.75;
                    neworder.Totalcost = orderedpizzas.Pizzascost;
                    Console.WriteLine("How many Meatlovers would you like:");
                    int mlscount = Int32.Parse(Console.ReadLine());
                    while (mlscount > pizzacount)
                    {
                        Console.WriteLine("Too many! Try again.");
                        mlscount = Int32.Parse(Console.ReadLine());
                    }
                    if (mlscount > 0)
                    {
                        orderedpizzas.Meatlover = "meatlover";
                        orderedpizzas.Meatloverqty = mlscount;
                    }
                    pizzacount = pizzacount - mlscount;
                    if (pizzacount > 0)
                    {
                        Console.WriteLine("How many Supreme would you like:");
                        int supcount = Int32.Parse(Console.ReadLine());
                        while (supcount > pizzacount)
                        {
                            Console.WriteLine("Too many! Try again.");
                            supcount = Int32.Parse(Console.ReadLine());
                        }
                        if (supcount > 0)
                        {
                            orderedpizzas.Supreme = "supreme";
                            orderedpizzas.Supremeqty = supcount;
                        }
                        pizzacount = pizzacount - supcount;
                        if (pizzacount > 0)
                        {
                            Console.WriteLine("How many Hawaiian would you like:");
                            int hawcount = Int32.Parse(Console.ReadLine());
                            while (hawcount > pizzacount)
                            {
                                Console.WriteLine("Too many! Try again.");
                                hawcount = Int32.Parse(Console.ReadLine());
                            }
                            if (hawcount > 0)
                            {
                                orderedpizzas.Hawaiian = "hawaiian";
                                orderedpizzas.Hawaiianqty = hawcount;
                            }
                            pizzacount = pizzacount - hawcount;
                        }
                        if (pizzacount > 0)
                        {
                            Console.WriteLine("How many Margherita would you like:");
                            int marcount = Int32.Parse(Console.ReadLine());
                            while (marcount > pizzacount)
                            {
                                Console.WriteLine("Too many! Try again.");
                                marcount = Int32.Parse(Console.ReadLine());
                            }
                            if (marcount > 0)
                            {
                                orderedpizzas.Margherita = "margherita";
                                orderedpizzas.Margheritaqty = marcount;
                            }
                            pizzacount = pizzacount - marcount;
                        }
                    }
                    neworder.Dateplaced = DateTime.Now;





                    PizzaRepository.Addpizzaorder(orderedpizzas);
                    PizzaRepository.Save();
                    orderedpizzas = PizzaRepository.Getopids().Last();
                    neworder.Opid = orderedpizzas.Orderedpizzasid;
                    PizzaRepository.Addorder(neworder);
                    PizzaRepository.Save();
                    neworder = PizzaRepository.Getorders().Last();
                    // neworder.Opid = orderedpizzas.Orderedpizzasid;   

                    var newhistory = new History();
                    newhistory.Userid = custuser.Userid;
                    newhistory.Storeid = pizzastore.Storeid;        ////////////////////////////////////
                    newhistory.Orderid = neworder.Orderid;
                    PizzaRepository.Addtohistory(newhistory);
                    PizzaRepository.Save();
                    /////display order
                    Console.WriteLine("\nYour Receipt:\n");
                    Console.WriteLine($"{custuser.Username}\n");
                    Console.WriteLine($"{local2.Street}, {local2.City}, {local2.State}\n");
                    Console.WriteLine($"Courtesy of {pizzastore.Name}\n");
                    Console.WriteLine($"You ordered: {orderedpizzas.Meatloverqty} Meatlovers," +
                        $" {orderedpizzas.Hawaiianqty} Hawaiian, {orderedpizzas.Supremeqty} Supreme, " +
                        $"{orderedpizzas.Margheritaqty}, Margherita\n");
                    Console.WriteLine($"Total: {neworder.Totalcost}\n");
                    Console.WriteLine($"Date Placed: {neworder.Dateplaced}");
                    /////display order          
                }
                else
                {
                    var historylist = PizzaRepository.Gethistory().ToList();
                    var userhistory = new List<History>();
                    for (var i = 0; i < historylist.Count(); i++)
                    {
                        if (custuser.Userid == historylist[i].Userid)
                        {
                            userhistory.Add(historylist[i]);
                        }
                    }
                    Console.WriteLine("\nYour history:\n");

                    for (var i = 0; i < userhistory.Count(); i++)
                    {
                        var userstore = PizzaRepository.Grabstore(userhistory[i].Storeid);
                        Console.WriteLine($"Ordered from: {userstore.Name}\n");
                        var userorder = PizzaRepository.Graborder(userhistory[i].Orderid);
                        var userlocation = PizzaRepository.Grablocation(userorder.Locationid);
                        Console.WriteLine($"Ordered to {userlocation.Street}, {userlocation.City}, {userlocation.State}\n");
                        double pizzasnum = userorder.Totalcost / 6.75;
                        Console.WriteLine($"Placed {pizzasnum} # of Pizzas at a cost of {userorder.Totalcost}\n\n");
                    }
                    
                }
            }
            else                // if your an employee
            {
                Console.WriteLine("Which location?:");
                Console.WriteLine("Pizza Palace North (N or n) or Pizza Palace Central(C or c):");
                var empinput = Console.ReadLine();
                var newstore = new Pizzastore();
                string storename;

                if(empinput == "N" || empinput == "n")
                {
                    storename = "Pizza Palace North";
                    var storelist = PizzaRepository.Getpizzastores().ToList();
                    for(var i = 0; i < storelist.Count(); i++)
                    {
                        if(storename == storelist[i].Name)
                        {
                            newstore = storelist[i];
                        }
                    }
                    
                    Console.WriteLine("\nWould you like to search users(U or u):");
                    Console.WriteLine("Would you like to search history(H or h):");
                    Console.WriteLine("Would you like to check inventory(I or i):\n");
                    empinput = Console.ReadLine();
                    if(empinput == "U" || empinput == "u")
                    {
                        var user = new Customer();
                        Console.WriteLine("what is their username?:");
                        var username = Console.ReadLine();
                        user = PizzaRepository.Grabcustomer(username);
                        var deflocation = PizzaRepository.Grablocation(user.Deflocationid);
                        Console.WriteLine("\nTheir default location: ");
                        Console.WriteLine($"{deflocation.Street}, {deflocation.City}, {deflocation.State}\n");
                        var allhistory = PizzaRepository.Gethistory().ToList();
                        var userhistory = new List<History>();
                        for(var i = 0; i < allhistory.Count(); i++)
                        {
                            if(user.Userid == allhistory[i].Userid && newstore.Storeid == allhistory[i].Storeid)
                            { userhistory.Add(allhistory[i]); }
                        }
                        Console.WriteLine($"And they've ordered from {storename}: {userhistory.Count()} times");
                    }
                    else if(empinput == "H" || empinput == "h")
                    {
                        var allhistory = PizzaRepository.Gethistory().ToList();
                        var locationhistory = new List<History>();

                        for (var i = 0; i < allhistory.Count(); i++)
                        {
                            if(newstore.Storeid == allhistory[i].Storeid)
                            { locationhistory.Add(allhistory[i]);}
                        }

                        Console.WriteLine("How would you like to display history?");
                        Console.WriteLine("By earliest(E or e), by latest(L or l)");
                        Console.WriteLine("by cheapest(C or c), or by most expensive(M or m)");
                        var dispinput = Console.ReadLine();
                        var locationdelivery = new Location();
                        var storeuser = new Customer();
                        var storeorder = new Orderdetails();
                        if(dispinput == "E" || dispinput == "e")
                        {
                            Console.WriteLine($"\n{storename} history by Earliest:\n");
                            for(var i = 0; i < locationhistory.Count(); i++)
                            {
                                storeuser = PizzaRepository.Grabcustomerbyid(locationhistory[i].Userid);
                                storeorder = PizzaRepository.Graborder(locationhistory[i].Orderid);
                                locationdelivery = PizzaRepository.Grablocation(storeorder.Locationid);
                                Console.WriteLine($"Delivered to: {locationdelivery.Street}, " +
                                    $"{locationdelivery.City}, {locationdelivery.State}\n");
                                double count = storeorder.Totalcost / 6.75;
                                Console.WriteLine($"{storeuser.Username} ordered {count} pizzas at a cost " +
                                    $"of {storeorder.Totalcost} on {storeorder.Dateplaced}\n");
                            }
                        }
                        else if(dispinput == "L" || dispinput == "l")
                        {
                            Console.WriteLine($"\n{storename} history by Latest:\n");
                            for (var i = locationhistory.Count() -1; i >= 0; i--)
                            {
                                storeuser = PizzaRepository.Grabcustomerbyid(locationhistory[i].Userid);
                                storeorder = PizzaRepository.Graborder(locationhistory[i].Orderid);
                                locationdelivery = PizzaRepository.Grablocation(storeorder.Locationid);
                                Console.WriteLine($"Delivered to: {locationdelivery.Street}, " +
                                    $"{locationdelivery.City}, {locationdelivery.State}\n");
                                double count = storeorder.Totalcost / 6.75;
                                Console.WriteLine($"{storeuser.Username} ordered {count} pizzas at a cost " +
                                    $"of {storeorder.Totalcost} on {storeorder.Dateplaced}\n");
                            }
                        }
                        else if(dispinput == "C" || dispinput == "c")
                        {
                            //have location history
                            var orderlist = new List<Orderdetails>();
                            //var historybycheap = new List<>
                            for(var i = 0; i< locationhistory.Count(); i++)
                            {
                                orderlist.Add(PizzaRepository.Graborder(locationhistory[i].Orderid));
                              //  Console.WriteLine("\n added order to order list\n");
                            }
                            var neworderlist = new List<Orderdetails>();
                            for(var i = 0; i < orderlist.Count(); i++)
                            {
                               // Console.WriteLine("loop of orderlist");
                                if(neworderlist.Count() == 0) { neworderlist.Add(orderlist[i]); }
                                else
                                {
                                    var k = neworderlist.Count() - 1;

                                    for (var j = 0; j < neworderlist.Count(); j++)
                                    {
                                        // Console.WriteLine("loop of neworderlist");


                                        if (orderlist[i].Totalcost < neworderlist[j].Totalcost )
                                        {
                                            neworderlist.Insert(j, orderlist[i]);
                                           // Console.WriteLine("\n inserted order to neworderlist\n");

                                        }
                                        else if( j == k)
                                        {
                                            neworderlist.Add(orderlist[i]);
                                           // Console.WriteLine("\n added order to neworderlist\n");
                                        }
                                    }
                                }
                            }
                            Console.WriteLine($"\n{storename} history by Cheapest:\n");
                            for (var i = 0; i < neworderlist.Count(); i++)
                            {
                                storeuser = PizzaRepository.Grabcustomerbyid(neworderlist[i].Customerid);
                             //   storeorder = PizzaRepository.Graborder(neworderlist[i].);
                                locationdelivery = PizzaRepository.Grablocation(neworderlist[i].Locationid);
                                Console.WriteLine($"Delivered to: {locationdelivery.Street}, " +
                                    $"{locationdelivery.City}, {locationdelivery.State}\n");
                                double count = neworderlist[i].Totalcost / 6.75;
                                Console.WriteLine($"{storeuser.Username} ordered {count} pizzas at a cost " +
                                    $"of {neworderlist[i].Totalcost} on {neworderlist[i].Dateplaced}\n");
                            }
                        }
                        else if (dispinput == "M" || dispinput == "m")
                        {
                            //have location history
                            var orderlist = new List<Orderdetails>();
                            //var historybycheap = new List<>
                            for (var i = 0; i < locationhistory.Count(); i++)
                            {
                                orderlist.Add(PizzaRepository.Graborder(locationhistory[i].Orderid));
                            }
                            var neworderlist = new List<Orderdetails>();
                            for (var i = 0; i < orderlist.Count(); i++)
                            {
                                if (neworderlist.Count() == 0) { neworderlist.Add(orderlist[i]); }
                                else
                                {
                                    for (var j = 0; j < neworderlist.Count(); j++)
                                    {
                                        if (orderlist[i].Totalcost > neworderlist[j].Totalcost)
                                        {
                                            neworderlist.Insert(j, orderlist[i]);
                                        }
                                        else if (j == (neworderlist.Count() - 1))
                                        {
                                            neworderlist.Add(orderlist[i]);
                                        }
                                    }
                                }
                            }
                            Console.WriteLine($"\n{storename} history by Most Expensive:\n");
                            for (var i = 0; i < neworderlist.Count(); i++)
                            {
                                storeuser = PizzaRepository.Grabcustomerbyid(neworderlist[i].Customerid);
                                //   storeorder = PizzaRepository.Graborder(neworderlist[i].);
                                locationdelivery = PizzaRepository.Grablocation(neworderlist[i].Locationid);
                                Console.WriteLine($"Delivered to: {locationdelivery.Street}, " +
                                    $"{locationdelivery.City}, {locationdelivery.State}\n");
                                double count = neworderlist[i].Totalcost / 6.75;
                                Console.WriteLine($"{storeuser.Username} ordered {count} pizzas at a cost " +
                                    $"of {neworderlist[i].Totalcost} on {neworderlist[i].Dateplaced}\n");
                            }
                        }
                    }
                    else if(empinput == "I" || empinput == "i")
                    {
                        Console.WriteLine("Function not availabe (coming soon)");
                    }
                }
                else if(empinput == "C" || empinput == "c")
                {
                    storename = "Pizza Palace Central";
                    var storelist = PizzaRepository.Getpizzastores().ToList();
                    for (var i = 0; i < storelist.Count(); i++)
                    {
                        if (storename == storelist[i].Name)
                        {
                            newstore = storelist[i];
                        }
                    }

                    Console.WriteLine("\nWould you like to search users(U or u):");
                    Console.WriteLine("Would you like to search history(H or h):");
                    Console.WriteLine("Would you like to check inventory(I or i):\n");
                    empinput = Console.ReadLine();
                    if (empinput == "U" || empinput == "u")
                    {
                        var user = new Customer();
                        Console.WriteLine("what is their username?:");
                        var username = Console.ReadLine();
                        user = PizzaRepository.Grabcustomer(username);
                        var deflocation = PizzaRepository.Grablocation(user.Deflocationid);
                        Console.WriteLine("\nTheir default location: ");
                        Console.WriteLine($"{deflocation.Street}, {deflocation.City}, {deflocation.State}\n");
                        var allhistory = PizzaRepository.Gethistory().ToList();
                        var userhistory = new List<History>();
                        for (var i = 0; i < allhistory.Count(); i++)
                        {
                            if (user.Userid == allhistory[i].Userid && newstore.Storeid == allhistory[i].Storeid)
                            { userhistory.Add(allhistory[i]); }
                        }
                        Console.WriteLine($"And they've ordered from {storename}: {userhistory.Count()} times");
                    }
                    else if (empinput == "H" || empinput == "h")
                    {
                        var allhistory = PizzaRepository.Gethistory().ToList();
                        var locationhistory = new List<History>();

                        for (var i = 0; i < allhistory.Count(); i++)
                        {
                            if (newstore.Storeid == allhistory[i].Storeid)
                            { locationhistory.Add(allhistory[i]); }
                        }

                        Console.WriteLine("How would you like to display history?");
                        Console.WriteLine("By earliest(E or e), by latest(L or l)");
                        Console.WriteLine("by cheapest(C or c), or by most expensive(M or m)");
                        var dispinput = Console.ReadLine();
                        var locationdelivery = new Location();
                        var storeuser = new Customer();
                        var storeorder = new Orderdetails();
                        if (dispinput == "E" || dispinput == "e")
                        {
                            Console.WriteLine($"\n{storename} history by Earliest:\n");
                            for (var i = 0; i < locationhistory.Count(); i++)
                            {
                                storeuser = PizzaRepository.Grabcustomerbyid(locationhistory[i].Userid);
                                storeorder = PizzaRepository.Graborder(locationhistory[i].Orderid);
                                locationdelivery = PizzaRepository.Grablocation(storeorder.Locationid);
                                Console.WriteLine($"Delivered to: {locationdelivery.Street}, " +
                                    $"{locationdelivery.City}, {locationdelivery.State}\n");
                                double count = storeorder.Totalcost / 6.75;
                                Console.WriteLine($"{storeuser.Username} ordered {count} pizzas at a cost " +
                                    $"of {storeorder.Totalcost} on {storeorder.Dateplaced}\n");
                            }
                        }
                        else if (dispinput == "L" || dispinput == "l")
                        {
                            Console.WriteLine($"\n{storename} history by Latest:\n");
                            for (var i = locationhistory.Count() - 1; i >= 0; i--)
                            {
                                storeuser = PizzaRepository.Grabcustomerbyid(locationhistory[i].Userid);
                                storeorder = PizzaRepository.Graborder(locationhistory[i].Orderid);
                                locationdelivery = PizzaRepository.Grablocation(storeorder.Locationid);
                                Console.WriteLine($"Delivered to: {locationdelivery.Street}, " +
                                    $"{locationdelivery.City}, {locationdelivery.State}\n");
                                double count = storeorder.Totalcost / 6.75;
                                Console.WriteLine($"{storeuser.Username} ordered {count} pizzas at a cost " +
                                    $"of {storeorder.Totalcost} on {storeorder.Dateplaced}\n");
                            }
                        }
                        else if (dispinput == "C" || dispinput == "c")
                        {
                            //have location history
                            var orderlist = new List<Orderdetails>();
                            //var historybycheap = new List<>
                            for (var i = 0; i < locationhistory.Count(); i++)
                            {
                                orderlist.Add(PizzaRepository.Graborder(locationhistory[i].Orderid));
                                Console.WriteLine("\n added order to order list\n");
                            }
                            var neworderlist = new List<Orderdetails>();
                            for (var i = 0; i < orderlist.Count(); i++)
                            {
                                Console.WriteLine("loop of orderlist");
                                if (neworderlist.Count() == 0) { neworderlist.Add(orderlist[i]); }
                                else
                                {
                                    var k = neworderlist.Count() - 1;

                                    for (var j = 0; j < neworderlist.Count(); j++)
                                    {
                                        Console.WriteLine("loop of neworderlist");


                                        if (orderlist[i].Totalcost < neworderlist[j].Totalcost)
                                        {
                                            neworderlist.Insert(j, orderlist[i]);
                                            Console.WriteLine("\n inserted order to neworderlist\n");

                                        }
                                        else if (j == k)
                                        {
                                            neworderlist.Add(orderlist[i]);
                                            Console.WriteLine("\n added order to neworderlist\n");
                                        }
                                    }
                                }
                            }
                            Console.WriteLine($"\n{storename} history by Cheapest:\n");
                            for (var i = 0; i < neworderlist.Count(); i++)
                            {
                                storeuser = PizzaRepository.Grabcustomerbyid(neworderlist[i].Customerid);
                                //   storeorder = PizzaRepository.Graborder(neworderlist[i].);
                                locationdelivery = PizzaRepository.Grablocation(neworderlist[i].Locationid);
                                Console.WriteLine($"Delivered to: {locationdelivery.Street}, " +
                                    $"{locationdelivery.City}, {locationdelivery.State}\n");
                                double count = neworderlist[i].Totalcost / 6.75;
                                Console.WriteLine($"{storeuser.Username} ordered {count} pizzas at a cost " +
                                    $"of {neworderlist[i].Totalcost} on {neworderlist[i].Dateplaced}\n");
                            }
                        }
                        else if (dispinput == "M" || dispinput == "m")
                        {
                            //have location history
                            var orderlist = new List<Orderdetails>();
                            //var historybycheap = new List<>
                            for (var i = 0; i < locationhistory.Count(); i++)
                            {
                                orderlist.Add(PizzaRepository.Graborder(locationhistory[i].Orderid));
                            }
                            var neworderlist = new List<Orderdetails>();
                            for (var i = 0; i < orderlist.Count(); i++)
                            {
                                if (neworderlist.Count() == 0) { neworderlist.Add(orderlist[i]); }
                                else
                                {
                                    for (var j = 0; j < neworderlist.Count(); j++)
                                    {
                                        if (orderlist[i].Totalcost > neworderlist[j].Totalcost)
                                        {
                                            neworderlist.Insert(j, orderlist[i]);
                                        }
                                        else if (j == (neworderlist.Count() - 1))
                                        {
                                            neworderlist.Add(orderlist[i]);
                                        }
                                    }
                                }
                            }
                            Console.WriteLine($"\n{storename} history by Most Expensive:\n");
                            for (var i = 0; i < neworderlist.Count(); i++)
                            {
                                storeuser = PizzaRepository.Grabcustomerbyid(neworderlist[i].Customerid);
                                //   storeorder = PizzaRepository.Graborder(neworderlist[i].);
                                locationdelivery = PizzaRepository.Grablocation(neworderlist[i].Locationid);
                                Console.WriteLine($"Delivered to: {locationdelivery.Street}, " +
                                    $"{locationdelivery.City}, {locationdelivery.State}\n");
                                double count = neworderlist[i].Totalcost / 6.75;
                                Console.WriteLine($"{storeuser.Username} ordered {count} pizzas at a cost " +
                                    $"of {neworderlist[i].Totalcost} on {neworderlist[i].Dateplaced}\n");
                            }
                        }
                    }
                    else if (empinput == "I" || empinput == "i")
                    {
                        Console.WriteLine("Function not availabe (coming soon)");
                    }
                }
            }
        }
    }
}
