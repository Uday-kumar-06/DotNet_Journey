USE HotelReservationDB;
GO

INSERT INTO RoomCategory(CategoryName, PricePerNight)
VALUES
('Standard', 2500),
('Deluxe', 4500),
('Suite', 7000);


INSERT INTO Customers(FullName, Email, PhoneNumber, City)
VALUES
('Uday Kumar', 'uday@gmail.com', '9876543210', 'Hyderabad'),
('Rahul Sharma', 'rahul@gmail.com', '9876543211', 'Delhi'),
('Priya Reddy', 'priya@gmail.com', '9876543212', 'Bangalore');


INSERT INTO Rooms(RoomNumber, CategoryID, RoomStatus)
VALUES
(101, 1, 'Available'),
(102, 2, 'Booked'),
(103, 3, 'Available');


INSERT INTO Reservations(CustomerID, RoomID, CheckInDate, CheckOutDate, ReservationStatus)
VALUES
(1, 2, '2026-05-23', '2026-05-25', 'Confirmed'),
(2, 1, '2026-05-24', '2026-05-26', 'Completed'),
(3, 3, '2026-05-25', '2026-05-28', 'Confirmed');

INSERT INTO Payments(ReservationID, Amount, PaymentMethod)
VALUES
(1, 9000, 'UPI'),
(2, 5000, 'Card'),
(3, 21000, 'Cash');


UPDATE Rooms
SET RoomStatus = 'Maintenance'
WHERE RoomID = 3;


DELETE FROM Payments
WHERE PaymentID = 2;

GO