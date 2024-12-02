using Project;

namespace TestProject
{
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        public void AddBook_ShouldAddBookToLibrary()
        {
            // Arrange
            var library = new Library();
            var book = new Book("1", "Test Book", new Author("Author Name", "Biography"), new Genre(GenreType.Fiction));

            // Act
            library.AddBook(book);

            // Assert
            Assert.IsTrue(library.Books.Contains(book));
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void LendBook_ShouldThrowException_WhenNotImplemented()
        {
            // Arrange
            var library = new Library();
            var book = new Book("1", "Test Book", new Author("Author Name", "Biography"), new Genre(GenreType.Fiction));
            var reader = new Reader("1", "Reader Name");

            // Act
            library.LendBook(book, reader, 7);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void AddBook_ShouldIncreaseLibraryBookCount()
        {
            // Arrange
            var library = new Library();
            var book = new Book("1", "Test Book", new Author("Author Name", "Biography"), new Genre(GenreType.Fiction));

            // Act
            library.AddBook(book);

            // Assert
            Assert.AreEqual(1, library.Books.Count);
        }

        [TestMethod]
        public void LendBook_ShouldAddBookToReaderBorrowedBooks()
        {
            // Arrange
            var library = new Library();
            var reader = new Reader("1", "Test Reader");
            var book = new Book("1", "Test Book", new Author("Author Name", "Biography"), new Genre(GenreType.Fiction));
            library.AddBook(book);

            // Act
            library.LendBook(book, reader, 7);

            // Assert
            Assert.IsTrue(reader.BorrowedBooks.ContainsKey(book));
        }

        [TestMethod]
        public void ReturnBook_ShouldRemoveBookFromReaderBorrowedBooks()
        {
            // Arrange
            var library = new Library();
            var reader = new Reader("1", "Test Reader");
            var book = new Book("1", "Test Book", new Author("Author Name", "Biography"), new Genre(GenreType.Fiction));
            library.AddBook(book);
            library.LendBook(book, reader, 7);

            // Act
            library.ReturnBook(book, reader);

            // Assert
            Assert.IsFalse(reader.BorrowedBooks.ContainsKey(book));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LendBook_ShouldThrowException_WhenBookNotFound()
        {
            // Arrange
            var library = new Library();
            var reader = new Reader("1", "Test Reader");
            var book = new Book("1", "Nonexistent Book", new Author("Author", "Bio"), new Genre(GenreType.Fiction));

            // Act
            library.LendBook(book, reader, 7);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LendBook_ShouldThrowException_WhenBookAlreadyLent()
        {
            // Arrange
            var library = new Library();
            var reader1 = new Reader("1", "Reader One");
            var reader2 = new Reader("2", "Reader Two");
            var book = new Book("1", "Test Book", new Author("Author Name", "Biography"), new Genre(GenreType.Fiction));
            library.AddBook(book);
            library.LendBook(book, reader1, 7);

            // Act
            library.LendBook(book, reader2, 7);
        }

        [TestMethod]
        public void GetBorrowedBooks_ShouldReturnAllBorrowedBooksByReader()
        {
            // Arrange
            var library = new Library();
            var reader = new Reader("1", "Test Reader");
            var book1 = new Book("1", "Book One", new Author("Author Name", "Biography"), new Genre(GenreType.Fiction));
            var book2 = new Book("2", "Book Two", new Author("Author Name", "Biography"), new Genre(GenreType.Mystery));
            library.AddBook(book1);
            library.AddBook(book2);
            library.LendBook(book1, reader, 7);
            library.LendBook(book2, reader, 7);

            // Act
            var borrowedBooks = library.GetBorrowedBooks(reader);

            // Assert
            Assert.AreEqual(2, borrowedBooks.Count);
            Assert.IsTrue(borrowedBooks.Contains(book1));
            Assert.IsTrue(borrowedBooks.Contains(book2));
        }

    }
}