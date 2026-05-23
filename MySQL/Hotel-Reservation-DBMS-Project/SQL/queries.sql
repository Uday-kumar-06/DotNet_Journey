USE HotelReservationDB;
GO

SELECT * FROM Customers;


SELECT FullName, City FROM Customers
WHERE City = 'Hyderabad';


SELECT * FROM Rooms
ORDER BY RoomNumber ASC;


SELECT SUM(Amount) AS TotalRevenue FROM Payments;

SELECT RC.CategoryName, COUNT(R.RoomID) AS TotalRooms
FROM RoomCategory RC
INNER JOIN Rooms R ON RC.CategoryID = R.CategoryID
GROUP BY RC.CategoryName;


SELECT RC.CategoryName,
COUNT(R.RoomID) AS TotalRooms FROM RoomCategory RC
INNER JOIN Rooms R ON RC.CategoryID = R.CategoryID
GROUP BY RC.CategoryName
HAVING COUNT(R.RoomID) > 0;

SELECT
C.FullName,
R.ReservationID,
R.CheckInDate,
R.CheckOutDate FROM Customers C 
INNER JOIN Reservations R ON C.CustomerID = R.CustomerID;

SELECT
C.FullName,
P.Amount,
P.PaymentMethod FROM Customers C
LEFT JOIN Reservations R ON C.CustomerID = R.CustomerID
LEFT JOIN Payments P ON R.ReservationID = P.ReservationID;

SELECT * FROM RoomCategory
WHERE PricePerNight >
(
    SELECT AVG(PricePerNight)
    FROM RoomCategory
);


SELECT FullName FROM Customers C
WHERE EXISTS
(
    SELECT 1
    FROM Reservations R
    WHERE C.CustomerID = R.CustomerID
);

SELECT
C.FullName,
RM.RoomNumber,
RC.CategoryName,
R.CheckInDate,
R.CheckOutDate FROM Reservations R
INNER JOIN Customers C ON R.CustomerID = C.CustomerID
INNER JOIN Rooms RM ON R.RoomID = RM.RoomID
INNER JOIN RoomCategory RC ON RM.CategoryID = RC.CategoryID;

SELECT
C.FullName,
P.Amount,
P.PaymentMethod,
P.PaymentDate FROM Payments P
INNER JOIN Reservations R ON P.ReservationID = R.ReservationID
INNER JOIN Customers C ON R.CustomerID = C.CustomerID;
