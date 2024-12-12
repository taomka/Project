using System;
using System.Collections.Generic;

namespace Project
{
    public class Reader
    {
        public string Id {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Name {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Список записів про позичені книги, дати їх видачі та повернення.
        /// </summary>
        public List<BorrowedBookEntry> BorrowedBooks {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Конструктор для створення читача.
        /// </summary>
        public Reader(string id, string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Додає запис про позичену книгу до списку позик читача.
        /// </summary>
        /// <param name="period">Кількість днів, на яку позичена книга.</param>
        public void BorrowBook(Book book, int period)
        {
            // Дата повернення розраховується на основі періоду позики.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Видаляє запис про книгу зі списку позик, якщо вона повернута.
        /// </summary>
        public void ReturnBook(Book book)
        {
            // Видалити відповідний запис зі списку BorrowedBooks.
            throw new NotImplementedException();
        }
    }
}
