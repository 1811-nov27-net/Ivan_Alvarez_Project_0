using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaPalace.DataAccess
{
    public partial class PizzaDBContext : DbContext
    {
        public PizzaDBContext()
        {
        }

        public PizzaDBContext(DbContextOptions<PizzaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Drinks> Drinks { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Inventorydrinks> Inventorydrinks { get; set; }
        public virtual DbSet<Inventorypizzas> Inventorypizzas { get; set; }
        public virtual DbSet<Inventorysides> Inventorysides { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Orderdetails> Orderdetails { get; set; }
        public virtual DbSet<Ordereddrinks> Ordereddrinks { get; set; }
        public virtual DbSet<Orderedpizzas> Orderedpizzas { get; set; }
        public virtual DbSet<Orderedsides> Orderedsides { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }
        public virtual DbSet<Pizzastore> Pizzastore { get; set; }
        public virtual DbSet<Sides> Sides { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("pk_customer_userid");

                entity.ToTable("Customer", "PizzaSC");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Dateplaced).HasColumnName("dateplaced");

                entity.Property(e => e.Deflocationid).HasColumnName("deflocationid");

                entity.Property(e => e.Haveorder).HasColumnName("haveorder");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Deflocation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.Deflocationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_to_location_locationid");
            });

            modelBuilder.Entity<Drinks>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("pk_drinks_name");

                entity.ToTable("Drinks", "PizzaSC");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasDefaultValueSql("((1.25))");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History", "PizzaSC");

                entity.Property(e => e.Historyid).HasColumnName("historyid");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_history_to_orderdetails_orderid");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.Storeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_history_to_pizzastore_storeid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_history_to_customer_userid");
            });

            modelBuilder.Entity<Inventorydrinks>(entity =>
            {
                entity.HasKey(e => e.Inventdrinkid)
                    .HasName("pk_inventorydrinks");

                entity.ToTable("Inventorydrinks", "PizzaSC");

                entity.Property(e => e.Inventdrinkid).HasColumnName("inventdrinkid");

                entity.Property(e => e.Drinkname)
                    .IsRequired()
                    .HasColumnName("drinkname")
                    .HasMaxLength(50);

                entity.Property(e => e.Itemamount)
                    .HasColumnName("itemamount")
                    .HasDefaultValueSql("((200))");

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.HasOne(d => d.DrinknameNavigation)
                    .WithMany(p => p.Inventorydrinks)
                    .HasForeignKey(d => d.Drinkname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventorydrinks_to_drinks_name");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventorydrinks)
                    .HasForeignKey(d => d.Storeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventorydrinks_to_pizzastore_storeid");
            });

            modelBuilder.Entity<Inventorypizzas>(entity =>
            {
                entity.HasKey(e => e.Inventpizzasid)
                    .HasName("pk_inventorypizzas");

                entity.ToTable("Inventorypizzas", "PizzaSC");

                entity.Property(e => e.Inventpizzasid).HasColumnName("inventpizzasid");

                entity.Property(e => e.Itemamount)
                    .HasColumnName("itemamount")
                    .HasDefaultValueSql("((200))");

                entity.Property(e => e.Pizzaname)
                    .IsRequired()
                    .HasColumnName("pizzaname")
                    .HasMaxLength(50);

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.HasOne(d => d.PizzanameNavigation)
                    .WithMany(p => p.Inventorypizzas)
                    .HasForeignKey(d => d.Pizzaname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventorypizzas_to_pizzas_name");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventorypizzas)
                    .HasForeignKey(d => d.Storeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventorypizzas_to_pizzastore_storeid");
            });

            modelBuilder.Entity<Inventorysides>(entity =>
            {
                entity.HasKey(e => e.Inventsidesid)
                    .HasName("pk_inventorysides");

                entity.ToTable("Inventorysides", "PizzaSC");

                entity.Property(e => e.Inventsidesid).HasColumnName("inventsidesid");

                entity.Property(e => e.Itemamount)
                    .HasColumnName("itemamount")
                    .HasDefaultValueSql("((200))");

                entity.Property(e => e.Sidename)
                    .IsRequired()
                    .HasColumnName("sidename")
                    .HasMaxLength(50);

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.HasOne(d => d.SidenameNavigation)
                    .WithMany(p => p.Inventorysides)
                    .HasForeignKey(d => d.Sidename)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventorysides_to_sides_name");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventorysides)
                    .HasForeignKey(d => d.Storeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventorysides_to_pizzastore_storeid");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "PizzaSC");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(2);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Orderdetails>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("pk_orderdetails_orderid");

                entity.ToTable("Orderdetails", "PizzaSC");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Dateplaced).HasColumnName("dateplaced");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Odid).HasColumnName("odid");

                entity.Property(e => e.Opid).HasColumnName("opid");

                entity.Property(e => e.Osid).HasColumnName("osid");

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.Property(e => e.Totalcost).HasColumnName("totalcost");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderdetails_to_customers_userid");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderdetails_to_location_locationid");

                entity.HasOne(d => d.Od)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Odid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderdetails_to_ordereddrinks_odid");

                entity.HasOne(d => d.Op)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Opid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderdetails_to_orderedpizzas_opid");

                entity.HasOne(d => d.Os)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Osid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderdetails_to_orderedsides_osid");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Storeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_orderdetails_to_pizzastore_storeid");
            });

            modelBuilder.Entity<Ordereddrinks>(entity =>
            {
                entity.ToTable("Ordereddrinks", "PizzaSC");

                entity.Property(e => e.Ordereddrinksid).HasColumnName("ordereddrinksid");

                entity.Property(e => e.Bluemoon)
                    .HasColumnName("bluemoon")
                    .HasMaxLength(50);

                entity.Property(e => e.Bluemoonqty).HasColumnName("bluemoonqty");

                entity.Property(e => e.Brisk)
                    .HasColumnName("brisk")
                    .HasMaxLength(50);

                entity.Property(e => e.Briskqty).HasColumnName("briskqty");

                entity.Property(e => e.Drinkscost).HasColumnName("drinkscost");

                entity.Property(e => e.Horchata)
                    .HasColumnName("horchata")
                    .HasMaxLength(50);

                entity.Property(e => e.Horchataqty).HasColumnName("horchataqty");

                entity.Property(e => e.Merlot)
                    .HasColumnName("merlot")
                    .HasMaxLength(50);

                entity.Property(e => e.Merlotqty).HasColumnName("merlotqty");

                entity.HasOne(d => d.BluemoonNavigation)
                    .WithMany(p => p.OrdereddrinksBluemoonNavigation)
                    .HasForeignKey(d => d.Bluemoon)
                    .HasConstraintName("fk_ordereddrinks_to_drinks_name_bl");

                entity.HasOne(d => d.BriskNavigation)
                    .WithMany(p => p.OrdereddrinksBriskNavigation)
                    .HasForeignKey(d => d.Brisk)
                    .HasConstraintName("fk_ordereddrinks_to_drinks_name_br");

                entity.HasOne(d => d.HorchataNavigation)
                    .WithMany(p => p.OrdereddrinksHorchataNavigation)
                    .HasForeignKey(d => d.Horchata)
                    .HasConstraintName("fk_ordereddrinks_to_drinks_name_h");

                entity.HasOne(d => d.MerlotNavigation)
                    .WithMany(p => p.OrdereddrinksMerlotNavigation)
                    .HasForeignKey(d => d.Merlot)
                    .HasConstraintName("fk_ordereddrinks_to_drinks_name_m");
            });

            modelBuilder.Entity<Orderedpizzas>(entity =>
            {
                entity.ToTable("Orderedpizzas", "PizzaSC");

                entity.Property(e => e.Orderedpizzasid).HasColumnName("orderedpizzasid");

                entity.Property(e => e.Hawaiian)
                    .HasColumnName("hawaiian")
                    .HasMaxLength(50);

                entity.Property(e => e.Hawaiianqty).HasColumnName("hawaiianqty");

                entity.Property(e => e.Margherita)
                    .HasColumnName("margherita")
                    .HasMaxLength(50);

                entity.Property(e => e.Margheritaqty).HasColumnName("margheritaqty");

                entity.Property(e => e.Meatlover)
                    .HasColumnName("meatlover")
                    .HasMaxLength(50);

                entity.Property(e => e.Meatloverqty).HasColumnName("meatloverqty");

                entity.Property(e => e.Pizzascost).HasColumnName("pizzascost");

                entity.Property(e => e.Supreme)
                    .HasColumnName("supreme")
                    .HasMaxLength(50);

                entity.Property(e => e.Supremeqty).HasColumnName("supremeqty");

                entity.HasOne(d => d.HawaiianNavigation)
                    .WithMany(p => p.OrderedpizzasHawaiianNavigation)
                    .HasForeignKey(d => d.Hawaiian)
                    .HasConstraintName("fk_orderedpizzas_to_pizzas_name_h");

                entity.HasOne(d => d.MargheritaNavigation)
                    .WithMany(p => p.OrderedpizzasMargheritaNavigation)
                    .HasForeignKey(d => d.Margherita)
                    .HasConstraintName("fk_orderedpizzas_to_pizzas_name_mh");

                entity.HasOne(d => d.MeatloverNavigation)
                    .WithMany(p => p.OrderedpizzasMeatloverNavigation)
                    .HasForeignKey(d => d.Meatlover)
                    .HasConstraintName("fk_orderedpizzas_to_pizzas_name_ml");

                entity.HasOne(d => d.SupremeNavigation)
                    .WithMany(p => p.OrderedpizzasSupremeNavigation)
                    .HasForeignKey(d => d.Supreme)
                    .HasConstraintName("fk_orderedpizzas_to_pizzas_name_s");
            });

            modelBuilder.Entity<Orderedsides>(entity =>
            {
                entity.ToTable("Orderedsides", "PizzaSC");

                entity.Property(e => e.Orderedsidesid).HasColumnName("orderedsidesid");

                entity.Property(e => e.Alfredopasta)
                    .HasColumnName("alfredopasta")
                    .HasMaxLength(50);

                entity.Property(e => e.Alfredopastaqty).HasColumnName("alfredopastaqty");

                entity.Property(e => e.Ceasarsalad)
                    .HasColumnName("ceasarsalad")
                    .HasMaxLength(50);

                entity.Property(e => e.Ceasarsaladqty).HasColumnName("ceasarsaladqty");

                entity.Property(e => e.Garlicbread)
                    .HasColumnName("garlicbread")
                    .HasMaxLength(50);

                entity.Property(e => e.Garlicbreadqty).HasColumnName("garlicbreadqty");

                entity.Property(e => e.Sidescost).HasColumnName("sidescost");

                entity.Property(e => e.Wings)
                    .HasColumnName("wings")
                    .HasMaxLength(50);

                entity.Property(e => e.Wingsqty).HasColumnName("wingsqty");

                entity.HasOne(d => d.AlfredopastaNavigation)
                    .WithMany(p => p.OrderedsidesAlfredopastaNavigation)
                    .HasForeignKey(d => d.Alfredopasta)
                    .HasConstraintName("fk_orderedsides_to_sides_name_a");

                entity.HasOne(d => d.CeasarsaladNavigation)
                    .WithMany(p => p.OrderedsidesCeasarsaladNavigation)
                    .HasForeignKey(d => d.Ceasarsalad)
                    .HasConstraintName("fk_orderedsides_to_sides_name_c");

                entity.HasOne(d => d.GarlicbreadNavigation)
                    .WithMany(p => p.OrderedsidesGarlicbreadNavigation)
                    .HasForeignKey(d => d.Garlicbread)
                    .HasConstraintName("fk_orderedsides_to_sides_name_g");

                entity.HasOne(d => d.WingsNavigation)
                    .WithMany(p => p.OrderedsidesWingsNavigation)
                    .HasForeignKey(d => d.Wings)
                    .HasConstraintName("fk_orderedsides_to_sides_name_w");
            });

            modelBuilder.Entity<Pizzas>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("pk_pizzas_name");

                entity.ToTable("Pizzas", "PizzaSC");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasDefaultValueSql("((6.75))");
            });

            modelBuilder.Entity<Pizzastore>(entity =>
            {
                entity.HasKey(e => e.Storeid)
                    .HasName("pk_pizzastore_storeid");

                entity.ToTable("Pizzastore", "PizzaSC");

                entity.HasIndex(e => e.Locationid)
                    .HasName("UQ__Pizzasto__306F78A7C729B045")
                    .IsUnique();

                entity.Property(e => e.Storeid).HasColumnName("storeid");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Location)
                    .WithOne(p => p.Pizzastore)
                    .HasForeignKey<Pizzastore>(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pizzastore_to_location_locationid");
            });

            modelBuilder.Entity<Sides>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("pk_sides_name");

                entity.ToTable("Sides", "PizzaSC");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasDefaultValueSql("((4.50))");
            });
        }
    }
}
