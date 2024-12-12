using Project;

namespace TestProject
{
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        public void AddBook_AddNewBookToInventory()
        {
            // Arrange
            var library = new Library();
            var book = new Book("1", "Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);

            // Act
            library.AddBook(book, 5);

            // Assert
            Assert.AreEqual(1, library.BookInventory.Count);
            Assert.AreEqual(book, library.BookInventory[0].Book);
            Assert.AreEqual(5, library.BookInventory[0].Quantity);
        }

        [TestMethod]
        public void AddBook_IncreaseQuantityForExistingBook()
        {
            // Arrange
            var library = new Library();
            var book = new Book("1", "Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            library.AddBook(book, 5);

            // Act
            library.AddBook(book, 3);

            // Assert
            Assert.AreEqual(1, library.BookInventory.Count);
            Assert.AreEqual(8, library.BookInventory[0].Quantity);
        }

        [TestMethod]
        public void LendBook_ReduceQuantityAndAddToBorrowedBooksLog()
        {
            // Arrange
            var library = new Library();
            var book = new Book("1", "Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            var reader = new Reader("1", "John Doe");
            library.AddBook(book, 5);

            // Act
            library.LendBook(book, reader, 14);

            // Assert
            Assert.AreEqual(4, library.BookInventory[0].Quantity);
            Assert.AreEqual(1, library.BorrowedBooksLog.Count);
            Assert.AreEqual(book, library.BorrowedBooksLog[0].Book);
            Assert.AreEqual(reader, library.BorrowedBooksLog[0].Reader);
        }

        [TestMethod]
        public void ReturnBook_IncreaseQuantityAndRemoveFromBorrowedBooksLog()
        {
            // Arrange
            var library = new Library();
            var book = new Book("1", "Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            var reader = new Reader("1", "John Doe");
            library.AddBook(book, 5);
            library.LendBook(book, reader, 14);

            // Act
            library.ReturnBook(book, reader);

            // Assert
            Assert.AreEqual(5, library.BookInventory[0].Quantity);
            Assert.AreEqual(0, library.BorrowedBooksLog.Count);
        }
    }
}