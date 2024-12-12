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
    }
}
