using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace Project
{
    public class Library
    {
        /// <summary>
        /// Список книг із кількістю.
        /// </summary>
        public List<BookInventoryEntry> BookInventory { get; set; }

        /// <summary>
        /// Список позик.
        /// </summary>
        public List<BorrowedBookEntry> BorrowedBooksLog { get; set; }

        public List<Reader> Readers { get; set; }

        /// <summary>
        /// Конструктор для ініціалізації списків.
        /// </summary>
        public Library()
        {
            BookInventory = new List<BookInventoryEntry>();
            BorrowedBooksLog = new List<BorrowedBookEntry>();
            Readers = new List<Reader>();
        }

        /// <summary>
        /// Додає книгу до інвентаря або збільшує кількість.
        /// </summary>
        public void AddBook(Book book, int quantity)
        {
            if (book == null) throw new ArgumentNullException(nameof(book), "Книга не може бути null.");
            if (quantity <= 0) throw new ArgumentException("Кількість має бути більше нуля.", nameof(quantity));
            var existingEntry = BookInventory.FirstOrDefault(entry => entry.Book.Title.Equals(book.Title, StringComparison.OrdinalIgnoreCase));

            if (existingEntry != null)
            {
                existingEntry.Book.TotalCopies += quantity;
                existingEntry.Book.AvailableCopies += quantity;
            }
            else
            {
                BookInventory.Add(new BookInventoryEntry(book, quantity));
            }
        }

        /// <summary>
        /// Видає книгу читачеві, зменшуючи кількість у BookInventory.
        /// </summary>
        public void LendBook(Book book, Reader reader, int period)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            if (period <= 0) throw new ArgumentException("Період має бути більше нуля.", nameof(period));
            if (reader.IsBlocked()) throw new InvalidOperationException($"Читач {reader.Name} заблокований до {reader.BlockedUntil?.ToShortDateString()}.");

            var inventoryEntry = BookInventory.FirstOrDefault(entry => entry.Book.Title == book.Title);
            if (inventoryEntry == null || inventoryEntry.Quantity <= 0)
            {
                throw new InvalidOperationException("Книга відсутня в бібліотеці.");
            }

            var borrowEntry = new BorrowedBookEntry(book, reader, DateTime.Now, DateTime.Now.AddDays(period));
            BorrowedBooksLog.Add(borrowEntry);
            reader.BorrowBook(book, period);

            inventoryEntry.Quantity--;
        }

        /// <summary>
        /// Повертає книгу в BookInventory і видаляє запис із BorrowedBooksLog.
        /// </summary>
        public string ReturnBook(Book book, Reader reader, bool isReturnedOnTime)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (reader == null) throw new ArgumentNullException(nameof(reader));

            var borrowEntry = BorrowedBooksLog.FirstOrDefault(entry => entry.Book.Title == book.Title && entry.Reader.Id == reader.Id);
            if (borrowEntry == null)
            {
                throw new InvalidOperationException("Ця книга не була позичена цим читачем.");
            }
            BorrowedBooksLog.Remove(borrowEntry);
            reader.ReturnBook(book);

            var inventoryEntry = BookInventory.FirstOrDefault(entry => entry.Book.Title == book.Title);
            if (inventoryEntry != null)
            {
                inventoryEntry.Quantity++;
            }
            else
            {
                BookInventory.Add(new BookInventoryEntry(book, 1));
            }
            if (!isReturnedOnTime)
            {
                reader.BlockedUntil = DateTime.Now.AddDays(30);
                return $"Читач {reader.Name} заблокований до {reader.BlockedUntil.Value.ToShortDateString()}.\nКнига '{book.Title}' успішно повернена.";
            }
            return $"Книга '{book.Title}' успішно повернена читачем {reader.Name}.";
        }

        private bool ReaderExist(Reader reader)
        {
            Reader? foundReader = Readers.Find(x => reader.Equals(x));
            return foundReader is Reader;
        }

        public void AddReader(Reader reader)
        {
            if (ReaderExist(reader))
            {
                throw new Exception("Читач з таким ім'ям вже існує");
            }
            Readers.Add(reader);
        }

        public Reader? FindReader(long Id)
        {
            Reader? foundReader = Readers.Find(x => x.Id == Id);
            return foundReader;
        }

        /// <summary>
        /// Виводить список книг із кількістю.
        /// </summary>
        public List<string> GetInventory()
        {
            return BookInventory.Select(entry =>
                $"Назва: {entry.Book.Title}, Кількість: {entry.Quantity}, Доступно копій: {entry.Book.AvailableCopies}").ToList();
        }

        /// <summary>
        /// Виводить список позик.
        /// </summary>
        public List<string> GetBorrowedBooksLog()
        {
            return BorrowedBooksLog.Select(entry =>entry.ToString()).ToList();
        }
    }    
}
