using Project;

namespace TestProject
{
    [TestClass]
    public class ReaderTests
    {
        [TestMethod]
        public void ReturnBook_ShouldRemoveBookFromBorrowedBooks()
        {
            // Arrange
            var reader = new Reader("1", "Test Reader");
            var book = new Book("1", "Test Book", new Author("Author Name", "Biography"), new Genre(GenreType.Fiction));
            reader.BorrowedBooks.Add(book, DateTime.Now);

            // Act
            reader.ReturnBook(book);

            // Assert
            Assert.IsFalse(reader.BorrowedBooks.ContainsKey(book));
        }

        [TestMethod]
        public void BorrowBook_ShouldAddBookToBorrowedBooksWithCorrectReturnDate()
        {
            // Arrange
            var reader = new Reader("1", "Test Reader");
            var book = new Book("1", "Test Book", new Author("Author Name", "Biography"), new Genre(GenreType.Fiction));

            // Act
            reader.BorrowBook(book, 7);

            // Assert
            Assert.IsTrue(reader.BorrowedBooks.ContainsKey(book));
            Assert.AreEqual(DateTime.Now.AddDays(7).Date, reader.BorrowedBooks[book].Date);
        }

        [TestMethod]
        public void BorrowBook_ShouldSetCorrectReturnDateForPeriod()
        {
            // Arrange
            var reader = new Reader("1", "Test Reader");
            var book = new Book("1", "Test Book", new Author("Author Name", "Biography"), new Genre(GenreType.Fiction));

            // Act
            reader.BorrowBook(book, 14);

            // Assert
            Assert.AreEqual(DateTime.Now.AddDays(14).Date, reader.BorrowedBooks[book].Date);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReturnBook_ShouldThrowException_WhenBookNotBorrowed()
        {
            // Arrange
            var reader = new Reader("1", "Test Reader");
            var book = new Book("1", "Test Book", new Author("Author Name", "Biography"), new Genre(GenreType.Fiction));

            // Act
            reader.ReturnBook(book);
        }

    }
}
