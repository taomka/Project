using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void Author_ShouldInitializeCorrectly()
        {
            // Arrange
            var author = new Author("Rowling", "British author, best known for Harry Potter series.");

            // Act & Assert
            Assert.AreEqual("Rowling", author.Name);
            Assert.AreEqual("British author, best known for Harry Potter series.", author.Biography);
        }
    }
}
