using Project;

namespace TestProject
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Constructor_InitializePropertiesCorrectly()
        {
            // Arrange
            var id = "1";
            var title = "Test Book";
            var authors = new List<Author> { new Author("Test Author") };
            var genre = GenreType.Fiction;
            var totalCopies = 10;

            // Act
            var book = new Book(id, title, authors, genre, totalCopies);

            // Assert
            Assert.AreEqual(id, book.Id);
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(authors, book.Authors);
            Assert.AreEqual(genre, book.Genre);
            Assert.AreEqual(totalCopies, book.TotalCopies);
            Assert.AreEqual(totalCopies, book.AvailableCopies);
        }
    }
}
