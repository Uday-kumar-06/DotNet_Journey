CREATE DATABASE CompanyDB;

USE CompanyDB;

CREATE TABLE Employees (
    EmpID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Department VARCHAR(50),
    Salary INT
);

INSERT INTO Employees VALUES (1, 'Rahul', 'Kumar', 'IT', 40000);
INSERT INTO Employees VALUES (2, 'Raja', 'Reddy', 'HR', 35000);
INSERT INTO Employees VALUES (3, 'Anil', 'Sharma', 'Finance', 60000);
INSERT INTO Employees VALUES (4, 'Sneha', 'Patel', 'IT', 50000);

CREATE FUNCTION GetFullName (
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50)
)
RETURNS VARCHAR(101)
AS
BEGIN
    RETURN @FirstName + ' ' + @LastName;
END;

SELECT 
    dbo.GetFullName(FirstName, LastName) AS FullName,
    Department,
    Salary
FROM Employees;