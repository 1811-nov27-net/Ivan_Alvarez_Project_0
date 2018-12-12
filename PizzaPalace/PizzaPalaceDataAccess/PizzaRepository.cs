using Microsoft.EntityFrameworkCore;
using PizzaPalace.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaPalace.DataAccess
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly PizzaDBContext _db;

        public PizzaRepository(PizzaDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IEnumerable<Library.Customer> Getcustomers()
        {
            return Mapper.Map(_db.Customer.Include(r => r.Deflocation).Include(a => a.History).Include(b => b.Orderdetails).AsNoTracking());
        }
        public IEnumerable<Library.History> Gethistory()
        {
            return Mapper.Map(_db.History.Include(r => r.Order).Include(a => a.Store).Include(b => b.User).AsNoTracking());
        }
        public IEnumerable<Library.Orderdetails> Getorders()
        {
            return Mapper.Map(_db.Orderdetails.Include(r => r.Customer).Include(a => a.Location).Include(b => b.Od).
                Include(c => c.Op).Include(d => d.Os).Include(f => f.Store).Include(g => g.History).AsNoTracking());
        }


        public IEnumerable<Library.Ordereddrinks> Getodids()
        {
            return Mapper.Map(_db.Ordereddrinks.Include(r => r.BluemoonNavigation).Include(a => a.MerlotNavigation).
         Include(c => c.BriskNavigation).Include(d => d.HorchataNavigation).Include(f => f.Orderdetails).AsNoTracking());
        }

        public IEnumerable<Library.Orderedpizzas> Getopids()
        {
            return Mapper.Map(_db.Orderedpizzas.Include(r => r.MeatloverNavigation).Include(a => a.SupremeNavigation).
                Include(d => d.HawaiianNavigation).Include(f => f.MargheritaNavigation).Include(q => q.Orderdetails).
                AsNoTracking());
          }
       // IEnumerable<Orderedsides> Getosids();
        public IEnumerable<Library.Pizzastore> Getpizzastores()
        {
            return Mapper.Map(_db.Pizzastore.Include(r => r.Location).Include(a => a.History).
             Include(c => c.Inventorydrinks).Include(d => d.Inventorypizzas).Include(f => f.Inventorysides).
            Include(t => t.Orderdetails).AsNoTracking());
        }
        //IEnumerable<Inventorydrinks> Getdrinkiventory();
        //IEnumerable<Inventorypizzas> Getpizzainveotry();
        //IEnumerable<Inventorysides> Getsideiventory();
        public IEnumerable<Library.Location> Getlocations()
        {
            return Mapper.Map(_db.Location.Include(r => r.Pizzastore).Include(a => a.Customer).
             Include(c => c.Orderdetails).AsNoTracking());
        }

        public void Addlocation(Library.Location local)
        {
            _db.Add(Mapper.Map(local));
        }
        public void Addorder(Library.Orderdetails order)
        {
            _db.Add(Mapper.Map(order));
        }
        public void Addpizzaorder(Library.Orderedpizzas pizzas)
        {
            _db.Add(Mapper.Map(pizzas));
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        
        public Library.Location Grablocation(int localid)
        {
            return Mapper.Map(_db.Location.Find(localid));
        }
       public Library.Location Grablocationbystreet(string street)
       {
            return Mapper.Map(_db.Location.Find(street));
       }
        public  Library.Pizzastore Grabstore(int storeid)
        {
            return Mapper.Map(_db.Pizzastore.Find(storeid));
        }
        public Library.Orderdetails Graborder(int orderid)
        {
            return Mapper.Map(_db.Orderdetails.Find(orderid));
        }
        public Library.Customer Grabcustomer(string username)
        {
             IEnumerable<Library.Customer> collectCust = Mapper.Map(_db.Customer.Where(r => r.Username == username));
            return collectCust.First();
        }
        public Library.Customer Grabcustomerbyid(int userid)
        {
            return Mapper.Map(_db.Customer.Find(userid));
        }

        public void Addtohistory(Library.History history)
        {
            _db.Add(Mapper.Map(history));
        }

    }
}