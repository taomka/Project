using Project;

namespace TestProject
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Book_ShouldInitializeCorrectly()
        {
            // Arrange
            var author = new Author("F. Scott Fitzgerald", "American author");
            var genre = new Genre(GenreType.Fiction);
            var book = new Book("1", "The Great Gatsby", author, genre);

            // Act & Assert
            Assert.AreEqual("1", book.Id);
            Assert.AreEqual("The Great Gatsby", book.Title);
            Assert.AreEqual("F. Scott Fitzgerald", book.Author.Name);
            Assert.AreEqual(GenreType.Fiction, book.Genre.Type);
        }
    }
}
