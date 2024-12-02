using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }

        public Book(string id, string title, Author author, Genre genre)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
        }
    }
}
