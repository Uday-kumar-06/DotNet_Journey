USE HotelReservationDB;
GO


BEGIN TRANSACTION;
UPDATE Rooms
SET RoomStatus = 'Booked'
WHERE RoomID = 1;
COMMIT;
PRINT 'Transaction Committed Successfully';
GO


SELECT *
FROM Rooms
WHERE RoomID = 1;
GO



BEGIN TRANSACTION;
DELETE FROM Customers
WHERE CustomerID = 3;
ROLLBACK;
PRINT 'Transaction Rolled Back';
GO




SELECT *
FROM Customers
WHERE CustomerID = 3;
GO



BEGIN TRY
    BEGIN TRANSACTION;
    UPDATE Payments
    SET Amount = Amount + 1000
    WHERE PaymentID = 1;
    UPDATE Payments
    SET PaymentMethod = 'Bitcoin'
    WHERE PaymentID = 1;
    COMMIT;
    PRINT 'Transaction Successful';
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT 'Transaction Failed';
    PRINT ERROR_MESSAGE();
END CATCH;
GO


SELECT *
FROM Payments;

GO