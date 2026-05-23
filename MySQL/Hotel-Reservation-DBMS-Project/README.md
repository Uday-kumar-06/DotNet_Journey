# Hotel Reservation DBMS Project

## Project Description
This project is a Hotel Reservation Database Management System developed using Microsoft SQL Server and SSMS.

The system manages:
- Customers
- Room Categories
- Rooms
- Reservations
- Payments

The project demonstrates core database concepts such as:
- DDL
- DML
- Constraints
- Joins
- Views
- Functions
- Triggers
- Transactions
- Indexes
- DCL Commands

---

## Features Implemented

### Database Design
- Primary Keys
- Foreign Keys
- Constraints
- Relationships

### SQL Operations
- INSERT
- UPDATE
- DELETE
- SELECT Queries

### Joins
- INNER JOIN
- LEFT JOIN

### Advanced SQL
- Views
- Functions
- Triggers
- Transactions
- Indexes

### Security
- GRANT
- REVOKE

---

## Database Tables

1. RoomCategory
2. Customers
3. Rooms
4. Reservations
5. Payments

---

## Tools Used

- Microsoft SQL Server
- SQL Server Management Studio (SSMS)

---

## How to Execute Project

Step 1:
Run `ddl_scripts.sql`

Step 2:
Run `dml_scripts.sql`

Step 3:
Run remaining SQL files one by one:
- queries.sql
- views.sql
- functions.sql
- triggers.sql
- transactions.sql
- indexes.sql
- dcl_commands.sql

---

## Sample Queries

### Display all customers
```sql
SELECT * FROM Customers;
```

### Customer reservation details
```sql
SELECT
C.FullName,
R.CheckInDate
FROM Customers C
INNER JOIN Reservations R
ON C.CustomerID = R.CustomerID;
```

---

## Project Outcome
This project successfully demonstrates the implementation of a normalized relational database system using SQL Server with advanced SQL concepts and database management techniques.