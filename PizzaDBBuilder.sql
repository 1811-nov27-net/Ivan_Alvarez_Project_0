create database PizzaDB
go

create schema PizzaSC

go

create table PizzaSC.Location
(
	locationid int identity not null,--pk
	street nvarchar(100) not null,
	city nvarchar(50) not null,
	state nvarchar(2) not null,-- as "ST" for State

	constraint pk_location_locationid primary key (locationid),
)	
--drop table PizzaSC.Location
insert into PizzaSC.Location (street, city, state) values
('7777 Luinguini st.', 'Arlington', 'TX'),--id 1
('1000 Mushroom dr.', 'Dallas', 'TX'),--id 2
('5555 Default ln.', 'Arlington', 'TX'),-- id 3
('1234 Main pl.', 'Fort Worth', 'TX');--id 4

create table PizzaSC.Drinks
(
	name nvarchar(50) not null,--pk; brisk, merlot, horchata, bluemoon
	cost float default 1.25 not null,

	constraint pk_drinks_name primary key (name),
)
--drop table PizzaSC.Drinks
insert into PizzaSC.Drinks (name) values
('brisk'),('merlot'),('horchata'),('bluemoon');

create table PizzaSC.Sides
(
	name nvarchar(50) not null,--pk; wings, ceasarsalad, garlicbread, alfredopasta
	cost float default 4.50 not null,

	constraint pk_sides_name primary key (name),
)
--drop table PizzaSC.Sides
insert into PizzaSC.Sides (name) values
('wings'),('ceasarsalad'),('garlicbread'),('alfredopasta');

create table PizzaSC.Pizzas
(
	name nvarchar(50) not null,--pk; meatlover, supreme, hawaiian, margherita
	cost float default 6.75 not null,

	constraint pk_pizzas_name primary key (name),
)
--drop table PizzaSC.Pizzas
insert into PizzaSC.Pizzas (name) values
('meatlover'),('supreme'),('hawaiian'),('margherita');

create table PizzaSC.Pizzastore
(
	storeid int identity not null,--pk
	name nvarchar(100) not null,
	locationid int unique not null,--fk to location table

	constraint pk_pizzastore_storeid primary key (storeid),
	constraint fk_pizzastore_to_location_locationid foreign key (locationid) references PizzaSC.Location (locationid),
)
--drop table PizzaSC.Pizzastore
insert into PizzaSC.Pizzastore (name, locationid) values
('Pizza Palace Central',1),--id 1
('Pizza Palace North',2);--id 2

select * from PizzaSC.Pizzastore

create table PizzaSC.Inventorydrinks
(
	storeid int not null,--fk to store
	drinkname nvarchar(50) not null,--fk to drinks
	itemamount int default 200 not null,

	constraint fk_inventorydrinks_to_pizzastore_storeid foreign key (storeid) references PizzaSC.Pizzastore (storeid),
	constraint fk_inventorydrinks_to_drinks_name foreign key (drinkname) references PizzaSC.Drinks (name),
)
--drop table PizzaSC.Inventorydrinks
insert into PizzaSC.Inventorydrinks (storeid, drinkname) values
(1,'brisk'),(1,'merlot'),(1,'horchata'),(1,'bluemoon'),(2,'brisk'),(2,'merlot'),(2,'horchata'),(2,'bluemoon');




create table PizzaSC.Inventorysides
(
	storeid int not null,--fk to store
	sidename nvarchar(50) not null,--fk to sides
	itemamount int default 200 not null,

	constraint fk_inventorysides_to_pizzastore_storeid foreign key (storeid) references PizzaSC.Pizzastore (storeid),
	constraint fk_inventorysides_to_sides_name foreign key (sidename) references PizzaSC.Sides (name),

)
--drop table PizzaSC.Inventorysides
insert into PizzaSC.Inventorysides (storeid, sidename) values
(1,'wings'),(1,'ceasarsalad'),(1,'garlicbread'),(1,'alfredopasta'),(2,'wings'),(2,'ceasarsalad'),(2,'garlicbread'),(2,'alfredopasta');



select * from PizzaSC.Inventorysides

--select * from PizzaSC.Inventorysides 

create table PizzaSC.Inventorypizzas
(
	storeid int not null,--fk to store
	pizzaname nvarchar(50) not null,--fk to pizzas
	itemamount int default 200 not null,

	constraint fk_inventorypizzas_to_pizzastore_storeid foreign key (storeid) references PizzaSC.Pizzastore (storeid),
	constraint fk_inventorypizzas_to_pizzas_name foreign key (pizzaname) references PizzaSC.Pizzas (name),
)
--drop table PizzaSC.Inventorypizzas
insert into PizzaSC.Inventorypizzas (storeid, pizzaname) values
(1,'meatlover'),(1,'supreme'),(1,'hawaiian'),(1,'margherita'),(2,'meatlover'),(2,'supreme'),(2,'hawaiian'),(2,'margherita');

alter table PizzaSC.Inventorypizzas
	add inventpizzasid int identity

alter table PizzaSC.Inventorypizzas
	add constraint pk_inventorypizzas primary key (inventpizzasid)

select * from PizzaSC.Inventorypizzas


create table PizzaSC.Customer
(
	userid int identity not null,--pk
	username nvarchar(100) not null,
	deflocationid int not null,--fk to location; stores default location
	haveorder bit default 0 not null,--if they can place an order again
--	currentorder int null,-- tracks if user has current order under 2 hours
	dateplaced datetime2 null,--will be checked everytime the program runs if its more than two hours it will reset to null and they 
																--can place another order

	constraint pk_customer_userid primary key (userid),
	constraint fk_customer_to_location_locationid foreign key (deflocationid) references PizzaSC.Location (locationid),
	--constraint fk_customer_to_orderdetails_orderid foreign key (currentorder) references PizzaSC.Orderdetails (orderid),

)
--drop table PizzaSC.Customer
insert into PizzaSC.Customer (username, deflocationid) values
('Pizzalover123', 3),('DonMario',4);
--id 1					--id 2
--select * from PizzaSC.Customer 

create table PizzaSC.Orderedsides
(
	orderedsidesid int identity(0,1) not null,--pk
	wings nvarchar(50) null,--must be allowed null; fk to sides table
	ceasarsalad nvarchar(50) null,--must be allowed null; fk to sides table
	garlicbread nvarchar(50) null,--must be allowed null; fk to sides table
	alfredopasta nvarchar(50) null,--must be allowed null; fk to sides table
	wingsqty int default 0 not null,
	ceasarsaladqty int default 0 not null,
	garlicbreadqty int default 0 not null,
	alfredopastaqty int default 0 not null,
	sidescost float default 0 not null,

	constraint pk_orderedsides_orderedsidesid primary key (orderedsidesid),
	constraint fk_orderedsides_to_sides_name_w foreign key (wings) references PizzaSC.Sides (name),
	constraint fk_orderedsides_to_sides_name_c foreign key (ceasarsalad) references PizzaSC.Sides (name),
	constraint fk_orderedsides_to_sides_name_g foreign key (garlicbread) references PizzaSC.Sides (name),
	constraint fk_orderedsides_to_sides_name_a foreign key (alfredopasta) references PizzaSC.Sides (name),
)
--drop table PizzaSC.Orderedsides
insert into PizzaSC.Orderedsides (wings,alfredopasta,wingsqty,alfredopastaqty,sidescost) values
('wings','alfredopasta',2,1,13.5);-- id 1
insert into PizzaSC.Orderedsides (wings, ceasarsalad,garlicbread,wingsqty,ceasarsaladqty,garlicbreadqty,sidescost) values
('wings','ceasarsalad','garlicbread',1,1,1,13.5); --id 2

--update PizzaSC.Orderedsides-
--set wings = 'wings', ceasarsalad = null, garlicbread = null, alfredopasta = 'alfredopasta', ceasarsaladqty = 0, garlicbreadqty = 0,
 --wingsqty = 2, alfredopastaqty = 1, sidescost = 13.5
--where orderedsidesid = 1

--select * from PizzaSC.Orderedsides

create table PizzaSC.Ordereddrinks
(
	ordereddrinksid int identity(0,1) not null, --pk
	brisk nvarchar(50) null, --must be allowed null; fk to drinks table
	merlot nvarchar(50) null, --must be allowed null; fk to drinks table
	horchata nvarchar(50) null, --allowed null; fk to drinks table
	bluemoon nvarchar(50) null, --allowed null; fk to drinks table
	briskqty int default 0 not null,
	merlotqty int default 0 not null,
	horchataqty int default 0 not null,
	bluemoonqty int default 0 not null,
	drinkscost float default 0 not null,
	
	constraint pk_ordereddrinks_ordereddrinksid primary key (ordereddrinksid),
	constraint fk_ordereddrinks_to_drinks_name_br foreign key (brisk) references PizzaSC.Drinks (name),
	constraint fk_ordereddrinks_to_drinks_name_m foreign key (merlot) references PizzaSC.Drinks (name),
	constraint fk_ordereddrinks_to_drinks_name_h foreign key (horchata) references PizzaSC.Drinks (name),
	constraint fk_ordereddrinks_to_drinks_name_bl foreign key (bluemoon) references PizzaSC.Drinks (name),
)
--drop table PizzaSC.Ordereddrinks

insert into PizzaSC.Ordereddrinks (brisk,briskqty,drinkscost) values
('brisk',4,5.0);-- id 1
insert into PizzaSC.Ordereddrinks (merlot,horchata,bluemoon,merlotqty,horchataqty,bluemoonqty,drinkscost) values
('merlot','horchata','bluemoon',2,2,1,6.25); -- id 2

--update PizzaSC.Ordereddrinks
--set ordereddrinksid = 0
--where ordereddrinksid  = 3

--select * from PizzaSC.Ordereddrinks

create table PizzaSC.Orderedpizzas
(--meatlover, supreme, hawaiian, margherita
	orderedpizzasid int identity(0,1) not null,--pk
	meatlover nvarchar(50) null,--must null; fk to pizzas table
	supreme nvarchar(50) null,--nullable; fk to pizzas table
	hawaiian nvarchar(50) null, --nullable; fk to pizzas table
	margherita nvarchar(50) null, --nullable; fk to pizzas table
	meatloverqty int default 0 not null,
	supremeqty int default 0 not null,
	hawaiianqty int default 0 not null,
	margheritaqty int default 0 not null,
	pizzascost float default 0 not null,

	constraint pk_orderedpizzas_orderedpizzasid primary key (orderedpizzasid),
	constraint fk_orderedpizzas_to_pizzas_name_ml foreign key (meatlover) references PizzaSC.Pizzas (name),
	constraint fk_orderedpizzas_to_pizzas_name_s foreign key (supreme) references PizzaSC.Pizzas (name),
	constraint fk_orderedpizzas_to_pizzas_name_h foreign key (hawaiian) references PizzaSC.Pizzas (name),
	constraint fk_orderedpizzas_to_pizzas_name_mh foreign key (margherita) references PizzaSC.Pizzas (name),
)
--drop table PizzaSC.Orderedpizzas
insert into PizzaSC.Orderedpizzas (supreme,margherita, supremeqty,margheritaqty, pizzascost) values
('supreme','margherita',1,1,13.5);--id 1
insert into PizzaSC.Orderedpizzas (meatlover,hawaiian,meatloverqty,hawaiianqty,pizzascost) values
('meatlover','hawaiian',1,2,20.25);-- id 2

--update PizzaSC.Orderedpizzas
--set meatlover = null, hawaiian = null, meatloverqty = 0, hawaiianqty = 0, pizzascost = 0
--where orderedpizzasid = 0


--select * from PizzaSC.Orderedpizzas

create table PizzaSC.Orderdetails
(
	orderid int identity not null,--pk
	customerid int not null,--fk to customers table
	storeid int not null ,--fk to pizzastore table
	locationid int not null , --fk to location table
	osid int default 0 not null ,--fk to ordersides table
	odid int default 0 not null ,--fk to orderedsrinks table
	opid int default 0 not null ,--fk to orderedpizzas table
	totalcost float default 0 not null,
	dateplaced datetime2 not null,--tracks when order was placed

	constraint pk_orderdetails_orderid primary key (orderid),
	constraint fk_orderdetails_to_customers_userid foreign key (customerid) references PizzaSC.Customer (userid),
	constraint fk_orderdetails_to_pizzastore_storeid foreign key (storeid) references PizzaSC.Pizzastore (storeid),
	constraint fk_orderdetails_to_location_locationid foreign key (locationid) references PizzaSC.Location (locationid),
	constraint fk_orderdetails_to_orderedsides_osid foreign key (osid) references PizzaSC.Orderedsides (orderedsidesid),
	constraint fk_orderdetails_to_ordereddrinks_odid foreign key (odid) references PizzaSC.Ordereddrinks (ordereddrinksid),
	constraint fk_orderdetails_to_orderedpizzas_opid foreign key (opid) references PizzaSC.Orderedpizzas (orderedpizzasid),
)
--drop table PizzaSC.Orderdetails
insert into PizzaSC.Orderdetails (customerid,storeid,locationid,osid,odid,opid,totalcost,dateplaced) values
(1,1,3,1,1,1, 32.0, current_timestamp);-- id 1
insert into PizzaSC.Orderdetails (customerid,storeid,locationid,osid,odid,opid,totalcost,dateplaced) values
(2,2,4,2,2,2, 40.0, current_timestamp);--id 2

--update PizzaSC.Orderdetails
--set osid = 0, opid = 0, odid = 0

select * from PizzaSC.Orderdetails

create table PizzaSC.History
(
	historyid int identity not null,--pk
	userid int not null,--fk to customer table
	storeid int not null,--fk to pizzastore table
	orderid int not null,--fk to orderdetails table
--	dateplaced datetime2 not null,--tracks when orders were placed
-- will get dateplaced from order table

	constraint pk_history_historyid primary key (historyid),
	constraint fk_history_to_customer_userid foreign key (userid) references PizzaSC.Customer (userid),
	constraint fk_history_to_pizzastore_storeid foreign key (storeid) references PizzaSC.Pizzastore (storeid),
	constraint fk_history_to_orderdetails_orderid foreign key (orderid) references PizzaSC.Orderdetails (orderid),
)
--drop table PizzaSC.History
insert into PizzaSC.History (userid, storeid, orderid) values 
(1,1,1), (2,2,2);
--id 1   --id 2
select * from PizzaSC.History
