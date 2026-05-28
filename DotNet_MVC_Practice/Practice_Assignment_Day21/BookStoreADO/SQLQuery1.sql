CREATE DATABASE BookStoreDB;
GO

USE BookStoreDB;
GO

CREATE TABLE Books
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100),
    Author NVARCHAR(100),
    Price DECIMAL(10,2),
    Quantity INT
);

CREATE PROCEDURE sp_UpdateBook
(
    @Id INT,
    @Title NVARCHAR(100),
    @Author NVARCHAR(100),
    @Price DECIMAL(10,2),
    @Quantity INT
)
AS
BEGIN
    UPDATE Books
    SET
        Title=@Title,
        Author=@Author,
        Price=@Price,
        Quantity=@Quantity
    WHERE Id=@Id
END

CREATE PROCEDURE sp_DeleteBook
(
    @Id INT
)
AS
BEGIN
    DELETE FROM Books
    WHERE Id=@Id
END

CREATE PROCEDURE sp_AddBook
(
    @Title NVARCHAR(100),
    @Author NVARCHAR(100),
    @Price DECIMAL(10,2),
    @Quantity INT
)
AS
BEGIN
    INSERT INTO Books(Title, Author, Price, Quantity)
    VALUES(@Title, @Author, @Price, @Quantity)
END
