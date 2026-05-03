CREATE DATABASE CompanyDB;

USE CompanyDB;

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    DepartmentName VARCHAR(50) NOT NULL
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(50) NOT NULL,
    Salary DECIMAL(10,2),
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY IDENTITY(1,1),
    ProjectName VARCHAR(100) NOT NULL,
    EmployeeID INT,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);

-- Insert Departments
INSERT INTO Departments (DepartmentName) VALUES
('HR'),
('IT'),
('Finance'),
('Marketing'),
('Sales'),
('Operations');

-- Insert Employees
INSERT INTO Employees (Name, Salary, DepartmentID) VALUES
('Uday', 50000, 2),
('Ravi', 45000, 1),
('Sneha', 60000, 3),
('Amit', 55000, 2),
('Priya', 48000, 4),
('Kiran', 70000, 3),
('Anjali', 52000, 5),
('Vikram', 61000, 6),
('Neha', 47000, 1),
('Rahul', 53000, 2),
('Pooja', 68000, 3),
('Arjun', 72000, 6),
('Meena', 49000, 4);

-- Insert Projects
INSERT INTO Projects (ProjectName, EmployeeID) VALUES
('Website Development', 1),
('Recruitment System', 2),
('Accounting App', 3),
('Mobile App', 4),
('Digital Marketing Campaign', 5),
('Cloud Migration', 6),
('HR Portal', 7),
('Sales Dashboard', 8),
('Inventory System', 9),
('AI Chatbot', 10),
('E-commerce Platform', 11),
('Data Analytics Tool', 12),
('Customer Support System', 13);





SELECT * FROM Departments;
SELECT * FROM Employees;
SELECT * FROM Projects;


CREATE TABLE EmployeeAudit (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    ActionType VARCHAR(20),
    ActionDate DATETIME DEFAULT GETDATE()
);

CREATE TRIGGER trg_AfterInsertEmployee
ON Employees
AFTER INSERT
AS
BEGIN
    INSERT INTO EmployeeAudit (EmployeeID, ActionType)
    SELECT EmployeeID, 'INSERT'
    FROM inserted;
END;

select * from EmployeeAudit;

INSERT INTO Employees (Name, Salary, DepartmentID)
VALUES ('TestUser', 40000, 1);