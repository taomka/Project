﻿using System;
using System.Collections.Generic;

namespace Project
{
    public class Book
    {
        public string Id
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Title
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Список авторів книги.
        /// </summary>
        public List<Author> Authors
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Жанр книги.
        /// </summary>
        public GenreType Genre {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Загальна кількість копій книги в бібліотеці.
        /// </summary>
        public int TotalCopies
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Кількість доступних копій книги для позики.
        /// </summary>
        public int AvailableCopies
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public Book(string id, string title, List<Author> authors, GenreType genre, int totalCopies)
        {
            throw new NotImplementedException();
        }
    }
}
