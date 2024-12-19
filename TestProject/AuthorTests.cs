using Project;

namespace TestProject
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void Constructor_InitializeNameCorrectly()
        {
            // Arrange
            var name = "Test Author";

            // Act
            var author = new Author(name);

            // Assert
            Assert.AreEqual(name, author.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithEmptyName()
        {
            // Act
            var author = new Author("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithWhitespaceName()
        {
            // Act
            var author = new Author("   ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithInvalidCharactersInName()
        {
            // Act
            var author = new Author("John123!");
        }

        [TestMethod]
        public void CompareTo_WithDifferentNames()
        {
            // Arrange
            var author1 = new Author("Alice");
            var author2 = new Author("Bob");

            // Act
            var result = author1.CompareTo(author2);

            // Assert
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareTo_WithSameNames()
        {
            // Arrange
            var author1 = new Author("Alice");
            var author2 = new Author("alice");

            // Act
            var result = author1.CompareTo(author2);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareTo_WithNullOther()
        {
            // Arrange
            var author = new Author("Alice");

            // Act
            var result = author.CompareTo(null);

            // Assert
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void ToString_ReturnFormattedString()
        {
            // Arrange
            var author = new Author("John Doe");

            // Act
            var result = author.ToString();

            // Assert
            var expected = "Автор: John Doe";
            Assert.AreEqual(expected, result);
        }
    }
}
