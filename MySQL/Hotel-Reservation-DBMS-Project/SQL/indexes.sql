USE HotelReservationDB;
GO


CREATE NONCLUSTERED INDEX idx_RoomNumber ON Rooms(RoomNumber);
GO


CREATE NONCLUSTERED INDEX idx_CustomerEmail ON Customers(Email);
GO



CREATE NONCLUSTERED INDEX idx_PaymentDate ON Payments(PaymentDate);
GO


SELECT * FROM Rooms
WHERE RoomNumber = 101;
GO

SELECT * FROM Customers
WHERE Email = 'uday@gmail.com';
GO


SELECT * FROM Payments
WHERE PaymentDate = GETDATE();
GO