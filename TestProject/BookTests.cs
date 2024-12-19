using Project;

namespace TestProject
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Constructor_InitializeProperties()
        {
            // Arrange
            var title = "Test Book";
            var authors = new List<Author> { new Author("Test Author") };
            var genre = GenreType.Fiction;
            var totalCopies = 10;

            // Act
            var book = new Book(title, authors, genre, totalCopies);

            // Assert
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(authors, book.Authors);
            Assert.AreEqual(genre, book.Genre);
            Assert.AreEqual(totalCopies, book.TotalCopies);
            Assert.AreEqual(totalCopies, book.AvailableCopies);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithEmptyTitle()
        {
            // Act
            var book = new Book("", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithNullAuthors()
        {
            // Act
            var book = new Book("Test Book", null, GenreType.Fiction, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithEmptyAuthors()
        {
            // Act
            var book = new Book("Test Book", new List<Author>(), GenreType.Fiction, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WithNegativeTotalCopies()
        {
            // Act
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, -1);
        }

        [TestMethod]
        public void DisplayInfo_ReturnFormattedString()
        {
            // Arrange
            var authors = new List<Author> { new Author("Author B"), new Author("Author A") };
            var book = new Book("Test Book", authors, GenreType.Fiction, 5);

            // Act
            var result = book.DisplayInfo();

            // Assert
            var expected = $"Назва: Test Book, Жанр: Fiction, Автори: Автор: Author A, Автор: Author B, Загальна кількість копій: 5, Доступна кількість копій: 5";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TotalCopies_Setter()
        {
            // Arrange
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 5);
            book.AvailableCopies = 4;

            // Act
            book.TotalCopies = 3;

            // Assert
            Assert.AreEqual(3, book.TotalCopies);
            Assert.AreEqual(3, book.AvailableCopies);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AvailableCopies_Setter_WithNegativeValue()
        {
            // Arrange
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 5);

            // Act
            book.AvailableCopies = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AvailableCopies_Setter_WithValueGreaterThanTotalCopies()
        {
            // Arrange
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 5);

            // Act
            book.AvailableCopies = 6;
        }
    }
}
