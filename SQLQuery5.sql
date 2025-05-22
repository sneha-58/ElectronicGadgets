CREATE PROCEDURE InsertCustomerData_TechShop
    @CustomerID INT,
    @FirstName VARCHAR(30),
    @LastName VARCHAR(50),
    @Email VARCHAR(50),
    @Phone VARCHAR(10),
	@Address VARCHAR(100)
AS
BEGIN
    INSERT INTO Customers (customerID, firstName, lastName, email, phone, customerAddress)
    VALUES (@CustomerID, @FirstName, @LastName, @Email, @Phone, @Address);
END
GO
-------------------------

CREATE PROCEDURE UpdateCustomerData_TechShop
    @CustomerID INT,
    @FirstName VARCHAR(30),
    @LastName VARCHAR(50),
    @Email VARCHAR(50),
    @Phone VARCHAR(10),
    @Address VARCHAR(100)
AS
BEGIN
    UPDATE Customers
    SET firstName = @FirstName,
        lastName = @LastName,
        email = @Email,
        phone = @Phone,
        customerAddress = @Address
    WHERE customerID = @CustomerID;
END
