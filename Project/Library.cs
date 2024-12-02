using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Library
    {
        public List<Book> Books { 
            get { throw new NotImplementedException(); } 
            set { throw new NotImplementedException(); }
        }
        public List<Reader> Readers {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Library()
        {
            throw new NotImplementedException();
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
