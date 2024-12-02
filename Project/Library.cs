using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Library
    {
        public List<Book> Books { get; set; }
        public List<Reader> Readers { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Readers = new List<Reader>();
        }

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void LendBook(Book book, Reader reader, int period)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(Book book, Reader reader)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBorrowedBooks(Reader reader)
        {
            throw new NotImplementedException();
        }
    }
}
