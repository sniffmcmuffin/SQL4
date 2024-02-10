-- Drop tables if they exist
DROP TABLE IF EXISTS Reviews;
DROP TABLE IF EXISTS ProductPrices;
DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS Products;
DROP TABLE IF EXISTS Manufacturers;
DROP TABLE IF EXISTS Categories;

-- Categories Table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(255)
);

-- Manufacturers Table
CREATE TABLE Manufacturers (
    ManufacturerID INT PRIMARY KEY,
    ManufacturerName VARCHAR(255)
);

-- Products Table
CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(255),
    Description TEXT,
    CategoryID INT,
    ManufacturerID INT,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) ON DELETE CASCADE,
    FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID) ON DELETE CASCADE
);

-- Customers Table
CREATE TABLE Customers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(20)
);

-- ProductPrices Table
CREATE TABLE ProductPrices (
    ProductID INT PRIMARY KEY,
    Price MONEY,
    FOREIGN KEY (ProductID) REFERENCES Products(Id) ON DELETE CASCADE
);

-- Reviews Table
CREATE TABLE Reviews (
    ReviewID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT,
    CustomerID INT,
    Rating INT,
    Comments TEXT,
    FOREIGN KEY (ProductID) REFERENCES Products(Id) ON DELETE CASCADE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(Id) ON DELETE CASCADE
);
