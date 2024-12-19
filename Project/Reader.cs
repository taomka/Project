using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Project
{
    public class Reader : Person, IComparable<Reader>, IEquatable<Reader>
    {
        private static long count = 0;
        private string _name;
        
        public long Id { get; set; }

        /// <summary>
        /// Ім'я читача. Може містити лише букви
        /// </summary>
        public override string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name не може бути порожнім або містити лише пробіли.", nameof(value));
                }
                if (!Regex.IsMatch(value, @"^[a-zA-Zа-яА-ЯїЇєЄіІ' ]+$"))
                {
                    throw new ArgumentException("Name може містити лише літери, пробіли та апостроф.", nameof(value));
                }
                _name = value;
            }
        }

        /// <summary>
        /// Список записів про позичені книги.
        /// </summary>
        public List<BorrowedBookEntry> BorrowedBooks { get; set; }

        public DateTime? BlockedUntil { get; set; }

        /// <summary>
        /// Конструктор для створення читача.
        /// </summary>
        public Reader(string name)
        {
            Name = name;
            BorrowedBooks = new List<BorrowedBookEntry>();
            BlockedUntil = null;
            Id = count;
            count++;
        }

        /// <summary>
        /// Перевіряє, чи читач заблокований.
        /// </summary>
        public bool IsBlocked()
        {
            return BlockedUntil.HasValue && BlockedUntil >= DateTime.Now;
        }

        /// <summary>
        /// Додає запис про позичену книгу до списку позик.
        /// </summary>
        /// <param name="book">Книга, яку позичає читач.</param>
        /// <param name="period">Кількість днів, на яку позичена книга.</param>
        public void BorrowBook(Book book, int period)
        {
            if (IsBlocked()) throw new InvalidOperationException($"Читач {Name} заблокований до {BlockedUntil?.ToShortDateString()} і не може брати книги.");
            if (book == null) throw new ArgumentNullException(nameof(book), "Книга не може бути null.");
            if (period <= 0) throw new ArgumentException("Період має бути більше нуля.", nameof(period));

            if (book.AvailableCopies <= 0)
            {
                throw new InvalidOperationException("Книга недоступна для позичення.");
            }
            var borrowDate = DateTime.Now;
            var dueDate = borrowDate.AddDays(period);

            BorrowedBooks.Add(new BorrowedBookEntry(book, this, borrowDate, dueDate));
            book.AvailableCopies--;
        }

        /// <summary>
        /// Видаляє запис про книгу зі списку позик, якщо вона повернута.
        /// </summary>
        /// <param name="book">Книга, яку повертає читач.</param>
        public void ReturnBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book), "Книга не може бути null.");

            var entry = BorrowedBooks.FirstOrDefault(b => b.Book == book);
            if (entry == null)
            {
                throw new InvalidOperationException("Ця книга не може бути запозичена читачем.");
            }
            BorrowedBooks.Remove(entry);
            book.AvailableCopies++;
        }

        public int CompareTo(Reader other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public bool Equals(Reader other)
        {
            return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase) && Id.Equals(other.Id);
        }

        /// <summary>
        /// Повертає текстове представлення об'єкта Reader.
        /// </summary>
        public override string ToString()
        {
            return $"Читач: {Name} (ID: {Id}), Запозичена книга: {BorrowedBooks.Count}";
        }
    }
}
