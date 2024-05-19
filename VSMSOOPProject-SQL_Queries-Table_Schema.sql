create database DB_VSMSOOPProject
-- Users Table
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
	PhoneNumber VARCHAR(20),
	Address VARCHAR(100),
    Role VARCHAR(50)
);

-- Customer Table
CREATE TABLE Customers (
    CustomerId INT PRIMARY KEY,
	Username VARCHAR(50) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    Address VARCHAR(200) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL,
    FOREIGN KEY (CustomerId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Salesman Table
CREATE TABLE Salesmen (
    SalesmanId INT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    FOREIGN KEY (SalesmanId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Administrative Table
CREATE TABLE Administrative (
    AdminId INT PRIMARY KEY,
	Username VARCHAR(50) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    FOREIGN KEY (AdminId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Supplier Table
CREATE TABLE Suppliers (
    SupplierId INT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(20) NOT NULL,
    FOREIGN KEY (SupplierId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE CASCADE
);

--Vehicle Image table
CREATE TABLE Vehicle_Image (
	ImageId INT PRIMARY KEY IDENTITY(1,1),
	VehicleId INT,
	ImageData IMAGE,
	FOREIGN KEY (VehicleId) REFERENCES Vehicles(VehicleId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Vehicle Table
CREATE TABLE Vehicles (
    VehicleId INT PRIMARY KEY IDENTITY(1,1),
    Make VARCHAR(50) NOT NULL,
    Model VARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    Color VARCHAR(20) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    Status VARCHAR(20) NOT NULL DEFAULT 'pending'
);

-- Car Table
CREATE TABLE Cars (
    CarId INT PRIMARY KEY,
	NoOfDoors INT NOT NULL,
    FOREIGN KEY (CarId) REFERENCES Vehicles(VehicleId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Bike Table
CREATE TABLE Bikes (
    BikeId INT PRIMARY KEY,
    FOREIGN KEY (BikeId) REFERENCES Vehicles(VehicleId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- FuelCar Table
CREATE TABLE FuelCars (
    FuelCarId INT PRIMARY KEY,
    FuelType VARCHAR(50) NOT NULL,
    FuelEfficiency DECIMAL(4,2) NOT NULL,
    FOREIGN KEY (FuelCarId) REFERENCES Vehicles(VehicleId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- ElectricCar Table
CREATE TABLE ElectricCars (
    ElectricCarId INT PRIMARY KEY,
    BatteryCapacity INT NOT NULL,
    ChargingTime DECIMAL(4,2) NOT NULL,
    FOREIGN KEY (ElectricCarId) REFERENCES Vehicles(VehicleId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- FuelBike Table
CREATE TABLE FuelBikes (
    FuelBikeId INT PRIMARY KEY,
    FuelTankCapacity INT NOT NULL,
	FuelMileage INT NOT NULL,
    FOREIGN KEY (FuelBikeId) REFERENCES Vehicles(VehicleId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- ElectricBike Table
CREATE TABLE ElectricBikes (
    ElectricBikeId INT PRIMARY KEY,
    BatteryCapacity INT NOT NULL,
    ChargingTime DECIMAL(4,2) NOT NULL,
    FOREIGN KEY (ElectricBikeId) REFERENCES Vehicles(VehicleId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Orders Table
CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    OrderDate DATE NOT NULL,
    TotalAmount DECIMAL(10,2) NOT NULL
);

-- Purchase Table
CREATE TABLE Purchases (
    PurchaseId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    SupplierId INT NOT NULL,
    SalesmanId INT NOT NULL,
    ApprovalStatus VARCHAR(20) NOT NULL DEFAULT 'pending',
    ApprovalDate DATE DEFAULT GETDATE(),
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId),
    FOREIGN KEY (SalesmanId) REFERENCES Salesmen(SalesmanId)
);

-- Sale Table
CREATE TABLE Sales (
    SaleId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    CustomerId INT NOT NULL,
    SalesmanId INT NOT NULL,
    ApprovalStatus VARCHAR(20) NOT NULL DEFAULT 'pending',
    ApprovalDate DATE DEFAULT GETDATE(),
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId),
    FOREIGN KEY (SalesmanId) REFERENCES Salesmen(SalesmanId)
);

-- SalesInvoice Table
CREATE TABLE SalesInvoices (
    SalesInvoiceId INT PRIMARY KEY IDENTITY(1,1),
    SaleId INT NOT NULL,
    PaymentStatus VARCHAR(20) NOT NULL,
    PaymentDate DATE,
    FOREIGN KEY (SaleId) REFERENCES Sales(SaleId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- PurchaseInvoice Table
CREATE TABLE PurchaseInvoices (
    PurchaseInvoiceId INT PRIMARY KEY IDENTITY(1,1),
    PurchaseId INT NOT NULL,
    PaymentStatus VARCHAR(20) NOT NULL,
    PaymentDate DATE,
    FOREIGN KEY (PurchaseId) REFERENCES Purchases(PurchaseId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Inventory Table
CREATE TABLE Inventory (
    InventoryId INT PRIMARY KEY IDENTITY(1,1),
    VehicleId INT NOT NULL,
    FOREIGN KEY (VehicleId) REFERENCES Vehicles(VehicleId) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Logger Table
CREATE TABLE Logger (
    LogId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    Activity VARCHAR(MAX),
    Timestamp DATETIME NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE ON UPDATE CASCADE
);

GO;
--Trigger to update inventory whenever a vehicle is inserted
CREATE TRIGGER UpdateInventory
ON Vehicles
AFTER INSERT, UPDATE
AS
BEGIN
    INSERT INTO Inventory (VehicleId)
	VALUES ((SELECT VehicleId
		   FROM inserted
		   WHERE status = 'approved'))
END;
GO;


GO;
--Adds the information to the required table when adding a new user
CREATE TRIGGER InsertIntoRoleSpecificTables
ON Users
AFTER INSERT
AS
BEGIN
    -- Insert into Customers table
    INSERT INTO Customers (Customers.CustomerId, Customers.Username, Customers.Password, Customers.Address, Customers.PhoneNumber)
    SELECT UserId, Username, Password, Address, PhoneNumber
    FROM inserted
    WHERE Role = 'Customer';

    -- Insert into Salesmen table
    INSERT INTO Salesmen (Salesmen.SalesmanId, Salesmen.Username, Salesmen.Password)
    SELECT UserId, Username, Password
    FROM inserted
    WHERE Role = 'Salesman';

    -- Insert into Administrative table
    INSERT INTO Administrative (Administrative.AdminId, Administrative.Username, Administrative.Password)
    SELECT UserId, Username, Password
    FROM inserted
    WHERE Role = 'Admin';

    -- Insert into Suppliers table
    INSERT INTO Suppliers (Suppliers.SupplierId, Suppliers.Username, Suppliers.Password, Suppliers.PhoneNumber)
    SELECT UserId, Username, Password, PhoneNumber
    FROM inserted
    WHERE Role = 'Supplier';
END;
GO;

SELECT * FROM dbo.Users
SELECT * FROM dbo.Administrative
SELECT * FROM dbo.Customers
SELECT * FROM dbo.Suppliers

INSERT INTO Users (Username, Password, Email, PhoneNumber, Address, Role) VALUES
('user1', 'password1', 'user1@example.com', '1234567890', '123 Main St', 'Customer'),
('user2', 'password2', 'user2@example.com', '1234567891', '124 Main St', 'Salesman'),
('user3', 'password3', 'user3@example.com', '1234567892', '125 Main St', 'Admin'),
('user4', 'password4', 'user4@example.com', '1234567893', '126 Main St', 'Supplier'),
('user5', 'password5', 'user5@example.com', '1234567894', '127 Main St', 'Customer'),
('user6', 'password6', 'user6@example.com', '1234567895', '128 Main St', 'Salesman'),
('user7', 'password7', 'user7@example.com', '1234567896', '129 Main St', 'Admin'),
('user8', 'password8', 'user8@example.com', '1234567897', '130 Main St', 'Supplier'),
('user9', 'password9', 'user9@example.com', '1234567898', '131 Main St', 'Customer'),
('user10', 'password10', 'user10@example.com', '1234567899', '132 Main St', 'Salesman'),
('user11', 'password11', 'user11@example.com', '1234567800', '133 Main St', 'Admin'),
('user12', 'password12', 'user12@example.com', '1234567801', '134 Main St', 'Supplier'),
('user13', 'password13', 'user13@example.com', '1234567802', '135 Main St', 'Customer'),
('user14', 'password14', 'user14@example.com', '1234567803', '136 Main St', 'Salesman'),
('user15', 'password15', 'user15@example.com', '1234567804', '137 Main St', 'Admin'),
('user16', 'password16', 'user16@example.com', '1234567805', '138 Main St', 'Supplier'),
('user17', 'password17', 'user17@example.com', '1234567806', '139 Main St', 'Customer'),
('user18', 'password18', 'user18@example.com', '1234567807', '140 Main St', 'Salesman'),
('user19', 'password19', 'user19@example.com', '1234567808', '141 Main St', 'Admin'),
('user20', 'password20', 'user20@example.com', '1234567809', '142 Main St', 'Supplier'),
('user21', 'password21', 'user21@example.com', '1234567810', '143 Main St', 'Customer'),
('user22', 'password22', 'user22@example.com', '1234567811', '144 Main St', 'Salesman'),
('user23', 'password23', 'user23@example.com', '1234567812', '145 Main St', 'Admin'),
('user24', 'password24', 'user24@example.com', '1234567813', '146 Main St', 'Supplier'),
('user25', 'password25', 'user25@example.com', '1234567814', '147 Main St', 'Customer'),
('user26', 'password26', 'user26@example.com', '1234567815', '148 Main St', 'Salesman'),
('user27', 'password27', 'user27@example.com', '1234567816', '149 Main St', 'Admin'),
('user28', 'password28', 'user28@example.com', '1234567817', '150 Main St', 'Supplier'),
('user29', 'password29', 'user29@example.com', '1234567818', '151 Main St', 'Customer'),
('user30', 'password30', 'user30@example.com', '1234567819', '152 Main St', 'Salesman'),
('user31', 'password31', 'user31@example.com', '1234567820', '153 Main St', 'Admin'),
('user32', 'password32', 'user32@example.com', '1234567821', '154 Main St', 'Supplier'),
('user33', 'password33', 'user33@example.com', '1234567822', '155 Main St', 'Customer'),
('user34', 'password34', 'user34@example.com', '1234567823', '156 Main St', 'Salesman'),
('user35', 'password35', 'user35@example.com', '1234567824', '157 Main St', 'Admin'),
('user36', 'password36', 'user36@example.com', '1234567825', '158 Main St', 'Supplier'),
('user37', 'password37', 'user37@example.com', '1234567826', '159 Main St', 'Customer'),
('user38', 'password38', 'user38@example.com', '1234567827', '160 Main St', 'Salesman'),
('user39', 'password39', 'user39@example.com', '1234567828', '161 Main St', 'Admin'),
('user40', 'password40', 'user40@example.com', '1234567829', '162 Main St', 'Supplier'),
('user41', 'password41', 'user41@example.com', '1234567830', '163 Main St', 'Customer'),
('user42', 'password42', 'user42@example.com', '1234567831', '164 Main St', 'Salesman'),
('user43', 'password43', 'user43@example.com', '1234567832', '165 Main St', 'Admin'),
('user44', 'password44', 'user44@example.com', '1234567833', '166 Main St', 'Supplier'),
('user45', 'password45', 'user45@example.com', '1234567834', '167 Main St', 'Customer'),
('user46', 'password46', 'user46@example.com', '1234567835', '168 Main St', 'Salesman'),
('user47', 'password47', 'user47@example.com', '1234567836', '169 Main St', 'Admin'),
('user48', 'password48', 'user48@example.com', '1234567837', '170 Main St', 'Supplier'),
('user49', 'password49', 'user49@example.com', '1234567838', '171 Main St', 'Customer'),
('user50', 'password50', 'user50@example.com', '1234567839', '172 Main St', 'Salesman');
