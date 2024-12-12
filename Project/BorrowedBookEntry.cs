using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public class BorrowedBookEntry
    {
        /// <summary>
        /// Позичена книга.
        /// </summary>
        public Book Book
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Читач, який позичив книгу.
        /// </summary>
        public Reader Reader
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Дата, коли книгу було позичено.
        /// </summary>
        public DateTime BorrowDate
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Дата, до якої книгу потрібно повернути.
        /// </summary>
        public DateTime DueDate
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public BorrowedBookEntry(Book book, Reader reader, DateTime borrowDate, DateTime dueDate)
        {
            throw new NotImplementedException();
        }
    }
}
