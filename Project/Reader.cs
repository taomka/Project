using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Reader
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Dictionary<Book, DateTime> BorrowedBooks { get; set; }

        public Reader(string id, string name)
        {
            Id = id;
            Name = name;
            BorrowedBooks = new Dictionary<Book, DateTime>();
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
