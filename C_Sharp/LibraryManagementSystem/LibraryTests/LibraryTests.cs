using LibraryManagementSystem.models;
using LibraryManagementSystem.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTests
{
    public class Tests
    {
        private Library library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
        }

        [Test]
        public void AddBook_ShouldAddBookSuccessfully()
        {
            var book = new Book { Title = "C#", Author = "MS", ISBN = "123" };

            library.AddBook(book);

            Assert.That(library.Books.Count, Is.EqualTo(1));
        }

        [Test]
        public void RegisterBorrower_ShouldRegisterSuccessfully()
        {
            var borrower = new Borrower { Name = "Uday", LibraryCardNumber = "001" };

            library.RegisterBorrower(borrower);

            Assert.That(library.Borrowers.Count, Is.EqualTo(1));
        }

        [Test]
        public void BorrowBook_ShouldMarkAsBorrowed()
        {
            var book = new Book { Title = "Java", Author = "ABC", ISBN = "111" };
            var borrower = new Borrower { Name = "Uday", LibraryCardNumber = "001" };

            library.AddBook(book);
            library.RegisterBorrower(borrower);

            library.BorrowBook("111", "001");

            Assert.That(book.IsBorrowed, Is.True);
            Assert.That(borrower.BorrowedBooks.Contains(book), Is.True);
        }

        [Test]
        public void ReturnBook_ShouldMarkAsAvailable()
        {
            var book = new Book { Title = "Python", Author = "XYZ", ISBN = "222" };
            var borrower = new Borrower { Name = "Uday", LibraryCardNumber = "001" };

            library.AddBook(book);
            library.RegisterBorrower(borrower);
            library.BorrowBook("222", "001");

            library.ReturnBook("222", "001");

            Assert.That(book.IsBorrowed, Is.False);
            Assert.That(borrower.BorrowedBooks.Contains(book), Is.False);
        }

        [Test]
        public void ViewBooks_ShouldReturnAllBooks()
        {
            library.AddBook(new Book { Title = "C++", Author = "Bjarne", ISBN = "333" });

            var books = library.ViewBooks();

            Assert.That(books.Count, Is.EqualTo(1));
        }

        [Test]
        public void ViewBorrowers_ShouldReturnAllBorrowers()
        {
            library.RegisterBorrower(new Borrower { Name = "Uday", LibraryCardNumber = "001" });

            var borrowers = library.ViewBorrowers();

            Assert.That(borrowers.Count, Is.EqualTo(1));
        }
    }
}
