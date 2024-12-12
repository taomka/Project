using System;
using System.Collections.Generic;

namespace Project
{
    public class Library
    {
        /// <summary>
        /// Список книг із кількістю.
        /// </summary>
        public List<BookInventoryEntry> BookInventory { 
            get { throw new NotImplementedException(); } 
            set { throw new NotImplementedException(); } 
        }

        /// <summary>
        /// Список позик.
        /// </summary>
        public List<BorrowedBookEntry> BorrowedBooksLog {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Library()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Додає книгу до інвентаря або збільшує кількість.
        /// </summary>
        public void AddBook(Book book, int quantity)
        { 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Видає книгу читачеві, зменшуючи кількість у BookInventory.
        /// </summary>
        public void LendBook(Book book, Reader reader, int period)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Повертає книгу в BookInventory і видаляє запис із BorrowedBooksLog.
        /// </summary>
        public void ReturnBook(Book book, Reader reader)
        { 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Виводить список книг із кількістю.
        /// </summary>
        public void PrintInventory()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Виводить список позик.
        /// </summary>
        public void PrintBorrowedBooksLog()
        {
            throw new NotImplementedException();
        }
    }    
}
