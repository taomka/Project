using Project;

namespace TestProject
{
    [TestClass]
    public class ReaderTests
    {
        [TestMethod]
        public void Constructor_InitializeProperties()
        {
            // Arrange
            var name = "John Doe";

            // Act
            var reader = new Reader(name);

            // Assert
            Assert.AreEqual(name, reader.Name);
            Assert.IsNotNull(reader.BorrowedBooks);
            Assert.AreEqual(0, reader.BorrowedBooks.Count);
            Assert.IsNull(reader.BlockedUntil);
        }

        [TestMethod]
        public void BorrowBook_AddBookToBorrowedBooksList()
        {
            // Arrange
            var reader = new Reader("John Doe");
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 3);
            int period = 7;

            // Act
            reader.BorrowBook(book, 7);

            // Assert
            Assert.AreEqual(1, reader.BorrowedBooks.Count);
            Assert.AreEqual(2, book.AvailableCopies);
            Assert.AreEqual(book, reader.BorrowedBooks[0].Book);
            Assert.AreEqual(DateTime.Now.Date, reader.BorrowedBooks[0].BorrowDate.Date);
            Assert.AreEqual(DateTime.Now.AddDays(period).Date, reader.BorrowedBooks[0].DueDate.Date);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Name_SetInvalidCharacters()
        {
            // Arrange
            var reader = new Reader("Valid Name");

            // Act
            reader.Name = "Invalid@Name123";
        }

        [TestMethod]
        public void ReturnBook_RemoveBookFromBorrowedBooksList()
        {
            // Arrange
            var reader = new Reader("John Doe");
            var book = new Book("Test Book", new List<Author> { new Author("Author") }, GenreType.Fiction, 3);
            reader.BorrowBook(book, 7);

            // Act
            reader.ReturnBook(book);

            // Assert
            Assert.AreEqual(0, reader.BorrowedBooks.Count);
            Assert.AreEqual(3, book.AvailableCopies);
        }

        [TestMethod]
        public void IsBlocked_WhenBlockedUntilFutureDate()
        {
            // Arrange
            var reader = new Reader("John Doe") { BlockedUntil = DateTime.Now.AddDays(5) };

            // Act
            var isBlocked = reader.IsBlocked();

            // Assert
            Assert.IsTrue(isBlocked);
        }

        [TestMethod]
        public void IsBlocked_WhenNotBlocked()
        {
            // Arrange
            var reader = new Reader("John Doe");

            // Act
            var isBlocked = reader.IsBlocked();

            // Assert
            Assert.IsFalse(isBlocked);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReturnBook_WithNullBook()
        {
            // Arrange
            var reader = new Reader("John Doe");

            // Act
            reader.ReturnBook(null);
        }

        [TestMethod]
        public void CompareTo_ReturnZeroForEqualReaders()
        {
            // Arrange
            var reader1 = new Reader("John Doe") { Id = 1 };
            var reader2 = new Reader("John Doe") { Id = 1 };

            // Act
            var comparisonResult = reader1.CompareTo(reader2);

            // Assert
            Assert.AreEqual(0, comparisonResult);
        }

        [TestMethod]
        public void CompareTo_ReturnPositiveForLexicographicallyLargerName()
        {
            // Arrange
            var reader1 = new Reader("John Doe");
            var reader2 = new Reader("Alice");

            // Act
            var comparisonResult = reader1.CompareTo(reader2);

            // Assert
            Assert.IsTrue(comparisonResult > 0);
        }

        [TestMethod]
        public void CompareTo_ReturnNegativeForLexicographicallySmallerName()
        {
            // Arrange
            var reader1 = new Reader("Alice");
            var reader2 = new Reader("John Doe");

            // Act
            var comparisonResult = reader1.CompareTo(reader2);

            // Assert
            Assert.IsTrue(comparisonResult < 0);
        }

        [TestMethod]
        public void Equals_ReturnTrueForSameNameAndId()
        {
            // Arrange
            var reader1 = new Reader("John Doe") { Id = 1 };
            var reader2 = new Reader("John Doe") { Id = 1 };

            // Act
            var isEqual = reader1.Equals(reader2);

            // Assert
            Assert.IsTrue(isEqual);
        }

        [TestMethod]
        public void Equals_ReturnFalseForDifferentId()
        {
            // Arrange
            var reader1 = new Reader("John Doe") { Id = 1 };
            var reader2 = new Reader("John Doe") { Id = 2 };

            // Act
            var isEqual = reader1.Equals(reader2);

            // Assert
            Assert.IsFalse(isEqual);
        }

        [TestMethod]
        public void ToString_ReturnFormattedString()
        {
            // Arrange
            var reader = new Reader("John Doe") { Id = 1 };

            // Act
            var result = reader.ToString();

            // Assert
            Assert.AreEqual("Читач: John Doe (ID: 1), Запозичена книга: 0", result);
        }
    }
}
