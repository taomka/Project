using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public Dictionary<Book, DateTime> BorrowedBooks {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Reader(string id, string name)
        {
            throw new NotImplementedException();
        }

        public void BorrowBook(Book book, int period)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
