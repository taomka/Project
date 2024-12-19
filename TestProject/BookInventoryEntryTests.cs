using Project;

namespace TestProject
{
    [TestClass]
    public class BookInventoryEntryTests
    {
        [TestMethod]
        public void Constructor_InitializeProperties()
        {
            // Arrange
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            int quantity = 5;

            // Act
            var entry = new BookInventoryEntry(book, quantity);

            // Assert
            Assert.AreEqual(book, entry.Book);
            Assert.AreEqual(quantity, entry.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenBookIsNull()
        {
            // Arrange & Act
            var entry = new BookInventoryEntry(null, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WhenQuantityIsNegative()
        {
            // Arrange & Act
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            var entry = new BookInventoryEntry(book, -1);
        }
    }
}
