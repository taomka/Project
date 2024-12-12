using Project;

namespace TestProject
{
    [TestClass]
    public class BorrowedBookEntryTests
    {
        [TestMethod]
        public void Constructor_InitializePropertiesCorrectly()
        {
            // Arrange
            var book = new Book("1", "Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            var reader = new Reader("1", "John Doe");
            var borrowDate = DateTime.Now;
            var dueDate = borrowDate.AddDays(14);

            // Act
            var entry = new BorrowedBookEntry(book, reader, borrowDate, dueDate);

            // Assert
            Assert.AreEqual(book, entry.Book);
            Assert.AreEqual(reader, entry.Reader);
            Assert.AreEqual(borrowDate, entry.BorrowDate);
            Assert.AreEqual(dueDate, entry.DueDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ThrowException_WhenBookIsNull()
        {
            // Arrange
            var reader = new Reader("1", "John Doe");
            var borrowDate = DateTime.Now;
            var dueDate = borrowDate.AddDays(14);

            // Act
            var entry = new BorrowedBookEntry(null, reader, borrowDate, dueDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ThrowException_WhenReaderIsNull()
        {
            // Arrange
            var book = new Book("1", "Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            var borrowDate = DateTime.Now;
            var dueDate = borrowDate.AddDays(14);

            // Act
            var entry = new BorrowedBookEntry(book, null, borrowDate, dueDate);
        }
    }
}
