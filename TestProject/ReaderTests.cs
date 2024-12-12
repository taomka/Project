using Project;

namespace TestProject
{
    [TestClass]
    public class ReaderTests
    {
        [TestMethod]
        public void Constructor_InitializePropertiesCorrectly()
        {
            // Arrange
            var id = "1";
            var name = "John Doe";

            // Act
            var reader = new Reader(id, name);

            // Assert
            Assert.AreEqual(id, reader.Id);
            Assert.AreEqual(name, reader.Name);
            Assert.AreEqual(0, reader.BorrowedBooks.Count);
        }

        [TestMethod]
        public void BorrowBook_AddBookToBorrowedBooksList()
        {
            // Arrange
            var reader = new Reader("1", "John Doe");
            var book = new Book("1", "Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            int period = 14;

            // Act
            reader.BorrowBook(book, period);

            // Assert
            Assert.AreEqual(1, reader.BorrowedBooks.Count);
            Assert.AreEqual(book, reader.BorrowedBooks[0].Book);
            Assert.AreEqual(DateTime.Now.Date, reader.BorrowedBooks[0].BorrowDate.Date);
            Assert.AreEqual(DateTime.Now.AddDays(period).Date, reader.BorrowedBooks[0].DueDate.Date);
        }

        [TestMethod]
        public void ReturnBook_RemoveBookFromBorrowedBooksList()
        {
            // Arrange
            var reader = new Reader("1", "John Doe");
            var book = new Book("1", "Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            reader.BorrowBook(book, 14);

            // Act
            reader.ReturnBook(book);

            // Assert
            Assert.AreEqual(0, reader.BorrowedBooks.Count);
        }
    }
}
