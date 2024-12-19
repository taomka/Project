using Project;

namespace TestProject
{
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        public void AddBook_AddNewBookToInventory()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);

            // Act
            library.AddBook(book, 5);

            // Assert
            Assert.AreEqual(1, library.BookInventory.Count);
            Assert.AreEqual(book, library.BookInventory[0].Book);
            Assert.AreEqual(5, library.BookInventory[0].Quantity);
        }

        [TestMethod]
        public void AddBook_IncreaseQuantityForExistingBook()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            library.AddBook(book, 8);

            // Act
            library.AddBook(book, 3);

            // Assert
            Assert.AreEqual(1, library.BookInventory.Count);
            Assert.AreEqual(8, library.BookInventory[0].Quantity);
        }

        [TestMethod]
        public void LendBook_ReduceQuantityAndAddToBorrowedBooksLog()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            var reader = new Reader("John Doe");
            library.AddBook(book, 5);

            // Act
            library.LendBook(book, reader, 14);

            // Assert
            Assert.AreEqual(4, library.BookInventory[0].Quantity);
            Assert.AreEqual(1, library.BorrowedBooksLog.Count);
            Assert.AreEqual(book, library.BorrowedBooksLog[0].Book);
            Assert.AreEqual(reader, library.BorrowedBooksLog[0].Reader);
        }

        [TestMethod]
        public void ReturnBook_IncreaseQuantityAndRemoveFromBorrowedBooksLog()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            var reader = new Reader("John Doe");
            library.AddBook(book, 5);
            library.LendBook(book, reader, 14);

            // Act
            library.ReturnBook(book, reader, true);

            // Assert
            Assert.AreEqual(5, library.BookInventory[0].Quantity);
            Assert.AreEqual(0, library.BorrowedBooksLog.Count);
        }

        [TestMethod]
        public void AddReader_ShouldAddReaderSuccessfully()
        {
            // Arrange
            var library = new Library();
            var reader = new Reader("Jane Doe");

            // Act
            library.AddReader(reader);

            // Assert
            Assert.AreEqual(1, library.Readers.Count);
            Assert.AreEqual(reader, library.Readers[0]);
        }

        [TestMethod]
        public void AddReader_DuplicateReader_ShouldThrowException()
        {
            // Arrange
            var library = new Library();
            var reader = new Reader("Jane Doe");
            library.AddReader(reader);

            // Act & Assert
            Assert.ThrowsException<Exception>(() => library.AddReader(reader));
        }

        [TestMethod]
        public void FindReader_ShouldReturnCorrectReader()
        {
            // Arrange
            var library = new Library();
            var reader = new Reader("Jane Doe") { Id = 1 };
            library.AddReader(reader);

            // Act
            var foundReader = library.FindReader(1);

            // Assert
            Assert.IsNotNull(foundReader);
            Assert.AreEqual(reader, foundReader);
        }

        [TestMethod]
        public void FindReader_NonExistentReader_ShouldReturnNull()
        {
            // Arrange
            var library = new Library();

            // Act
            var foundReader = library.FindReader(1);

            // Assert
            Assert.IsNull(foundReader);
        }

        [TestMethod]
        public void GetInventory_ShouldReturnInventoryList()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            library.AddBook(book, 5);

            // Act
            var inventory = library.GetInventory();

            // Assert
            Assert.AreEqual(1, inventory.Count);
            Assert.AreEqual("Назва: Test Book, Кількість: 5, Доступно копій: 10", inventory[0]);
        }

        [TestMethod]
        public void GetBorrowedBooksLog_ShouldReturnBorrowedBooksList()
        {
            // Arrange
            var library = new Library();
            var book = new Book("Test Book", new List<Author> { new Author("Test Author") }, GenreType.Fiction, 10);
            var reader = new Reader("John Doe");
            library.AddBook(book, 5);
            library.LendBook(book, reader, 7);

            // Act
            var borrowedBooks = library.GetBorrowedBooksLog();

            // Assert
            Assert.AreEqual(1, borrowedBooks.Count);
            Assert.IsTrue(borrowedBooks[0].Contains("Test Book"));
        }
    }
}
