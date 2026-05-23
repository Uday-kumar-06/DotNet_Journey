
--CREATE DATABASE HotelReservationDB;
--GO

USE HotelReservationDB;
GO



CREATE TABLE RoomCategory
(
    CategoryID INT PRIMARY KEY IDENTITY(1,1),

    CategoryName VARCHAR(50) NOT NULL UNIQUE,

    PricePerNight DECIMAL(10,2) NOT NULL
    CHECK (PricePerNight > 0)
);



CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY IDENTITY(1,1),

    FullName VARCHAR(100) NOT NULL,

    Email VARCHAR(100) UNIQUE NOT NULL,

    PhoneNumber VARCHAR(15) UNIQUE NOT NULL,

    City VARCHAR(50),

    CHECK (LEN(PhoneNumber) >= 10)
);



CREATE TABLE Rooms
(
    RoomID INT PRIMARY KEY IDENTITY(1,1),

    RoomNumber INT UNIQUE NOT NULL,

    CategoryID INT NOT NULL,

    RoomStatus VARCHAR(20)
    CHECK (RoomStatus IN ('Available','Booked','Maintenance')),

    FOREIGN KEY (CategoryID)
    REFERENCES RoomCategory(CategoryID)
);



CREATE TABLE Reservations
(
    ReservationID INT PRIMARY KEY IDENTITY(1,1),

    CustomerID INT NOT NULL,

    RoomID INT NOT NULL,

    CheckInDate DATE NOT NULL,

    CheckOutDate DATE NOT NULL,

    ReservationStatus VARCHAR(20)
    CHECK (ReservationStatus IN ('Confirmed','Cancelled','Completed')),

    FOREIGN KEY (CustomerID)
    REFERENCES Customers(CustomerID),

    FOREIGN KEY (RoomID)
    REFERENCES Rooms(RoomID)
);


CREATE TABLE Payments
(
    PaymentID INT PRIMARY KEY IDENTITY(1,1),

    ReservationID INT NOT NULL,

    Amount DECIMAL(10,2) NOT NULL
    CHECK (Amount > 0),

    PaymentDate DATE DEFAULT GETDATE(),

    PaymentMethod VARCHAR(20)
    CHECK (PaymentMethod IN ('Cash','Card','UPI')),

    FOREIGN KEY (ReservationID)
    REFERENCES Reservations(ReservationID)
);

GO