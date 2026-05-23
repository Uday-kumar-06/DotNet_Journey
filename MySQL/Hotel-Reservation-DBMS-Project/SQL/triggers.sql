USE HotelReservationDB;
GO

CREATE TABLE ReservationAudit
(
    AuditID INT PRIMARY KEY IDENTITY(1,1),
    ReservationID INT,
    ActionPerformed VARCHAR(20),
    ActionDate DATETIME DEFAULT GETDATE()
);
GO



CREATE TRIGGER trg_AfterInsertReservation
ON Reservations
AFTER INSERT
AS
BEGIN
    INSERT INTO ReservationAudit
    (
        ReservationID,
        ActionPerformed
    )
    SELECT
        ReservationID,
        'INSERT'
    FROM inserted;
END;
GO



INSERT INTO Reservations
(
    CustomerID,
    RoomID,
    CheckInDate,
    CheckOutDate,
    ReservationStatus
)

VALUES
(1, 1, '2026-06-01', '2026-06-05', 'Confirmed');
GO



CREATE TRIGGER trg_AfterUpdateReservation
ON Reservations
AFTER UPDATE

AS
BEGIN

    INSERT INTO ReservationAudit
    (
        ReservationID,
        ActionPerformed
    )
    SELECT
        ReservationID,
        'UPDATE'
    FROM inserted;
END;
GO


UPDATE Reservations
SET ReservationStatus = 'Completed'
WHERE ReservationID = 1;
GO

CREATE TRIGGER trg_AfterDeleteReservation
ON Reservations
AFTER DELETE
AS
BEGIN
    INSERT INTO ReservationAudit
    (
        ReservationID,
        ActionPerformed
    )

    SELECT
        ReservationID,
        'DELETE'

    FROM deleted;
END;
GO


DELETE FROM Reservations
WHERE ReservationID = 2;
GO


SELECT *
FROM ReservationAudit;
GO