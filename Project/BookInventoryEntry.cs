using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class BookInventoryEntry
    {
        private Book _book;
        private int _quantity;

        /// <summary>
        /// Книги які є у інвентарі.
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
        /// Кількість книг.
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Quantity), "Кількість не може бути від’ємною.");
                }
                _quantity = value;
            }
        }

        /// <summary>
        /// Конструктор для створення запису про книгу.
        /// </summary>
        /// <param name="book">Книга.</param>
        /// <param name="quantity">Кількість екземплярів книги.</param>
        public BookInventoryEntry(Book book, int quantity)
        {
            Book = book;
            Quantity = quantity;
        }

        /// <summary>
        /// Повертає текстове представлення запису інвентаря.
        /// </summary>
        public override string ToString()
        {
            return $"Книга: {Book.Title}, Кількість: {Quantity}";
        }
    }
}
