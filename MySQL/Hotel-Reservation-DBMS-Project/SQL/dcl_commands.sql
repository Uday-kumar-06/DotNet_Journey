USE HotelReservationDB;
GO


CREATE LOGIN HotelUser
WITH PASSWORD = 'Hotel@123';
GO


CREATE USER HotelUser
FOR LOGIN HotelUser;
GO



GRANT SELECT
ON Customers
TO HotelUser;
GO


GRANT INSERT
ON Reservations
TO HotelUser;
GO


GRANT UPDATE
ON Payments
TO HotelUser;
GO


REVOKE UPDATE
ON Payments
FROM HotelUser;
GO