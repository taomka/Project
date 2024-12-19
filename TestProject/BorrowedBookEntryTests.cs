using Project;

namespace TestProject
{
    [TestClass]
    public class BorrowedBookEntryTests
    {
        [TestMethod]
        public void Constructor_InitializeProperties()
        {
            // Arrange
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            var reader = new Reader("John Doe");
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
        public void Constructor_WhenBookIsNull()
        {
            // Arrange
            var reader = new Reader("John Doe");
            var borrowDate = DateTime.Now;
            var dueDate = borrowDate.AddDays(14);

            // Act
            var entry = new BorrowedBookEntry(null, reader, borrowDate, dueDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenReaderIsNull()
        {
            // Arrange
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            var borrowDate = DateTime.Now;
            var dueDate = borrowDate.AddDays(14);

            // Act
            var entry = new BorrowedBookEntry(book, null, borrowDate, dueDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithFutureBorrowDate()
        {
            // Arrange
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 5);
            var reader = new Reader("John Doe");
            var borrowDate = DateTime.Now.AddDays(1);
            var dueDate = DateTime.Now.AddDays(5);

            // Act
            var entry = new BorrowedBookEntry(book, reader, borrowDate, dueDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithDueDateBeforeBorrowDate()
        {
            // Arrange
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 5);
            var reader = new Reader("John Doe");
            var borrowDate = DateTime.Now.AddDays(-2);
            var dueDate = DateTime.Now.AddDays(-3);

            // Act
            var entry = new BorrowedBookEntry(book, reader, borrowDate, dueDate);
        }

        [TestMethod]
        public void ToString_ReturnFormattedString()
        {
            // Arrange
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 5);
            var reader = new Reader("John Doe");
            var borrowDate = DateTime.Now.AddDays(-2);
            var dueDate = DateTime.Now.AddDays(5);
            var entry = new BorrowedBookEntry(book, reader, borrowDate, dueDate);

            // Act
            var result = entry.ToString();

            // Assert
            var expected = $"Книга: Test Book, Запозичено: John Doe, День запозичення: {borrowDate.ToShortDateString()}, День повернення позики: {dueDate.ToShortDateString()}";
            Assert.AreEqual(expected, result);
        }
    }
}
