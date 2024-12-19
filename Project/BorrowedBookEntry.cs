using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class BorrowedBookEntry
    {
        private Book _book;
        private Reader _reader;
        private DateTime _borrowDate;
        private DateTime _dueDate;

        /// <summary>
        /// Позичена книга.
        /// </summary>
        public Book Book
        {
            get => _book;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Book), "Книга не може бути null.");
                }
                _book = value;
            }
        }

        /// <summary>
        /// Читач, який позичив книгу.
        /// </summary>
        public Reader Reader
        {
            get => _reader;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Reader), "Читач не може бути null.");
                }
                _reader = value;
            }
        }

        /// <summary>
        /// Дата, коли книгу було позичено.
        /// </summary>
        public DateTime BorrowDate
        {
            get => _borrowDate;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException("Дата позики не може бути в майбутньому.", nameof(BorrowDate));
                }
                _borrowDate = value;
            }
        }

        /// <summary>
        /// Дата, до якої книгу потрібно повернути.
        /// </summary>
        public DateTime DueDate
        {
            get => _dueDate;
            set
            {
                if (value <= BorrowDate)
                {
                    throw new ArgumentException("Термін повернення має бути після дати позики.", nameof(DueDate));
                }
                _dueDate = value;
            }
        }

        /// <summary>
        /// Конструктор для створення запису про позичену книгу.
        /// </summary>
        /// <param name="book">Книга, яку позичили.</param>
        /// <param name="reader">Читач, який позичив книгу.</param>
        /// <param name="borrowDate">Дата позики.</param>
        /// <param name="dueDate">Дата повернення.</param>
        public BorrowedBookEntry(Book book, Reader reader, DateTime borrowDate, DateTime dueDate)
        {
            Book = book;
            Reader = reader;
            BorrowDate = borrowDate;
            DueDate = dueDate;
        }

        /// <summary>
        /// Повертає текстове представлення запису про позичену книгу.
        /// </summary>
        public override string ToString()
        {
            return $"Книга: {Book.Title}, Запозичено: {Reader.Name}, День запозичення: {BorrowDate.ToShortDateString()}, День повернення позики: {DueDate.ToShortDateString()}";
        }
    }
}
