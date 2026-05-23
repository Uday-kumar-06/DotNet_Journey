USE HotelReservationDB;
GO


CREATE VIEW CustomerView
AS
SELECT
    CustomerID,
    FullName,
    Email,
    City
FROM Customers;
GO


CREATE VIEW ReservationDetailsView
AS
SELECT
    C.FullName,
    RM.RoomNumber,
    RC.CategoryName,
    R.CheckInDate,
    R.CheckOutDate,
    R.ReservationStatus FROM Reservations R
INNER JOIN Customers C ON R.CustomerID = C.CustomerID
INNER JOIN Rooms RM ON R.RoomID = RM.RoomID
INNER JOIN RoomCategory RC ON RM.CategoryID = RC.CategoryID;
GO


CREATE VIEW CustomerPaymentSummary
AS
SELECT
    C.FullName,
    SUM(P.Amount) AS TotalPayment FROM Customers C
INNER JOIN Reservations R ON C.CustomerID = R.CustomerID
INNER JOIN Payments P ON R.ReservationID = P.ReservationID
GROUP BY C.FullName;
GO




SELECT * FROM CustomerView;

SELECT * FROM ReservationDetailsView;

SELECT * FROM CustomerPaymentSummary;

GO