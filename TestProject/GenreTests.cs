using Project;

namespace TestProject
{
    [TestClass]
    public class GenreTests
    {
        [TestMethod]
        public void Genre_ShouldInitializeCorrectly()
        {
            // Arrange
            var genre = new Genre(GenreType.Mystery);

            // Act & Assert
            Assert.AreEqual(GenreType.Mystery, genre.Type);
        }

        [TestMethod]
        public void Genre_ShouldBeEqual_WhenTypeIsSame()
        {
            // Arrange
            var genre1 = new Genre(GenreType.Fiction);
            var genre2 = new Genre(GenreType.Fiction);

            // Act & Assert
            Assert.AreEqual(genre1.Type, genre2.Type);
        }

    }
}
