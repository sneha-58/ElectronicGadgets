--Task 1
use TechShop;
go

create table Customers(
customerID int primary key,
firstName varchar(30), 
lastName varchar(30), 
email varchar(30), 
phone bigint, 
customerAddress varchar(30)
);

INSERT INTO Customers VALUES
(101, 'Rachel', 'Green', 'rachel.green@gmail.com', 9876543210, '123 Street, NY'),
(102, 'Ross', 'Geller', 'ross.geller@gmail.com', 9123456789, '456 Lane, LA'),
(103, 'Joey', 'Tribbiani', 'joey.tribbiani@gmail.com', 9234567890, '789 Blvd, TX'),
(104, 'Chandler', 'Bing', 'chandler.bing@gmail.com', 9345678901, '101 Ave, FL'),
(105, 'Monica', 'Geller', 'monica.geller@gmail.com', 9456789012, '202 Road, IL'),
(106, 'Phoebe', 'Buffay', 'phoebe.buffay@gmail.com', 9567890123, '303 Drive, CA'),
(107, 'Steve', 'Harrington', 'steve.harrington@gmail.com', 9678901234, '404 Path, NV'),
(108, 'Will', 'Byers', 'will.byers@gmail.com', 9789012345, '505 Route, GA'),
(109, 'Dustin', 'Henderson', 'dustin.henderson@gmail.com', 9890123456, '606 Way, OH'),
(110, 'Jane', 'Hopper', 'jane.hopper@gmail.com', 9901234567, '707 Trail, MI');

select * from customers

create table Products(
productID int primary key,
productName varchar(30),
productDescription varchar(50),
price int
);

INSERT INTO Products VALUES
(1, 'Laptop', 'Dell Inspiron 15', 50000),
(2, 'Phone', 'Samsung Galaxy S21', 40000),
(3, 'Tablet', 'Apple iPad Pro', 60000),
(4, 'Monitor', 'LG 27-inch', 15000),
(5, 'Keyboard', 'Mechanical Keyboard', 5000),
(6, 'Mouse', 'Wireless Mouse', 2000),
(7, 'Headphones', 'Noise Cancelling Headphones', 8000),
(8, 'Smartwatch', 'Apple Watch Series 7', 35000),
(9, 'Speaker', 'Bluetooth Speaker', 7000),
(10, 'Router', 'WiFi 6 Router', 10000);

create table Orders(
OrderID int primary key,
customerID int,
orderDate date,
totalAmount int
foreign key (customerID) references Customers(customerID)
);

INSERT INTO Orders VALUES
(1, 101, '2025-03-01', 90000),
(2, 102, '2025-03-02', 55000),
(3, 103, '2025-03-03', 75000),
(4, 104, '2025-03-04', 45000),
(5, 105, '2025-03-05', 30000),
(6, 106, '2025-03-06', 70000),
(7, 107, '2025-03-07', 85000),
(8, 108, '2025-03-08', 95000),
(9, 109, '2025-03-09', 100000),
(10,110, '2025-03-10', 65000);

create table OrderDetails(
orderDetailID int primary key,
orderID int,
productID int,
quantity int,
foreign key (orderID) REFERENCES Orders(orderID),
foreign key (productID) REFERENCES Products(productID)
);

INSERT INTO OrderDetails VALUES
(1, 1, 1, 1),
(2, 1, 3, 1),
(3, 2, 2, 1),
(4, 3, 4, 2),
(5, 4, 5, 1),
(6, 5, 6, 1),
(7, 6, 7, 1),
(8, 7, 8, 1),
(9, 8, 9, 1),
(10, 9, 10, 1);

create table Inventory(
inventoryID int primary key,
productID int,
quantityInStock int,
lastStockUpdate date,
foreign key (productID) references Products(productID)
);

INSERT INTO Inventory VALUES
(1, 1, 10, '2025-03-01'),
(2, 2, 15, '2024-11-03'),
(3, 3, 8, '2024-09-03'),
(4, 4, 12, '2025-03-04'),
(5, 5, 20, '2024-10-24'),
(6, 6, 18, '2025-03-06'),
(7, 7, 7, '2024-11-08'),
(8, 8, 9, '2025-03-08'),
(9, 9, 6, '2025-03-09'),
(10, 10, 5, '2025-03-10');












----------------------------------------------------------
--select * from sys.sysobjects							 
--where xtype = 'U';									 

--select * from TechShop.INFORMATION_SCHEMA.TABLES;      
