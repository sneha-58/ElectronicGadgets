use TechShop;
go


--TASK 2
--1) Write an SQL query to retrieve the names and emails of all customers.
select firstName+' '+lastName as Name, email from Customers;                                      

--2) Write an SQL query to list all orders with their order dates and corresponding customer names.
select orderDate as 'Order Date', firstName+' '+lastName as Name from Orders                       
full join Customers
on Orders.customerID = Customers.customerID;

--3) Write an SQL to insert a new customer record into the "Customers" table.Include customer information such as name,email,and address.
insert into Customers values(																	   
111, 'Mike', 'Hannigan', 'mike.hannigan@gmail.com',9753186420,'12 Lane, NYC'
);

--4) Write an SQL query to update the prices of all electronic gadgets in the "Products" table by increasing them by 10%.
update Products								                                                       
set price = price + (price*0.1);
select * from Products;

--5) Write an SQL query to delete a specific order and its associated order details from the "Orders" and "OrderDetails" tables. Allow users to input the order ID as a parameter.
declare @orderID int = 7;
delete from OrderDetails where orderID = @orderID;
delete from Orders where orderID = @orderID;

select * from Orders;
select * from OrderDetails;

--6) Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, order date, and any other necessary info.
insert into Orders values(
12, 111, '2024-10-03', 25000
);
select * from Orders;

insert into OrderDetails values(
11,12,8,2
);

--7) Write an SQL query to update the contact information of a specific customer in the "Customers" table. Allow users to input the customer ID and new contact information.
declare @customerID int = 101;
declare @newEmail varchar(30) = 'rachel.emma@gmail.com';
update Customers set email = @newEmail
where customerID = @customerID;
select * from Customers;

--8) Write an SQL query to recalculate and update the total cost of each order in the "Orders" table based on the prices and quantities in the "OrderDetails" table.
select * from Orders;
select * from OrderDetails;
select Orders.OrderID, totalAmount from Orders
join OrderDetails
on Orders.orderID = OrderDetails.orderID;

--9) Write an SQL query to delete all orders and their associated order details for a specific customer from the "Orders" and "OrderDetails" tables. Allow users to input the customer ID as a parameter.
declare @oID int = 1;
delete from OrderDetails where orderID = @oID;
delete from Orders where orderID = @oID;

--10) Write an SQL query to insert a new electronic gadget product into the "Products" table, including product name, category, price, and any other relevant details.
insert into Products values(
11,'Joystick','CLAW Shoot Wireless',1500
);

--11) Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from "Pending" to "Shipped"). Allow users to input the order ID and the new status.
alter table Orders add status varchar(20) default 'Pending';

declare @OrderrID int = 4; 
declare @NewStatus varchar(20) = 'Shipped';

update Orders
set status = @NewStatus
where orderID = @OrderrID;
update Orders
set status = 'Pending'
where status IS NULL;
select * from Orders;

--12)Write an SQL query to calculate and update the number of orders placed by each customer in the "Customers" table based on the data in the "Orders" table.
select * from Customers;
select * from Orders;

alter table Customers
add numberOfOrders int;

update Customers
set numberOfOrders = (
	select count(*) from Orders
	where Orders.customerID = Customers.customerID
);

select * from Customers;