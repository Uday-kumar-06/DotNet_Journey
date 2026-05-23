USE HotelReservationDB;
GO

CREATE FUNCTION dbo.CalculateGST
(
    @Amount DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    RETURN @Amount * 0.18;
END;
GO



SELECT
dbo.CalculateGST(5000) AS GSTAmount;
GO


CREATE FUNCTION dbo.GetAvailableRooms()
RETURNS TABLE
AS
RETURN
(
    SELECT
        RoomID,
        RoomNumber,
        RoomStatus
    FROM Rooms
    WHERE RoomStatus = 'Available'
);
GO



SELECT *
FROM dbo.GetAvailableRooms();
GO



CREATE FUNCTION dbo.TotalStayDays
(
    @CheckIn DATE,
    @CheckOut DATE
)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(DAY, @CheckIn, @CheckOut);
END;
GO



SELECT dbo.TotalStayDays('2026-05-23','2026-05-28')
AS TotalDays;
GO