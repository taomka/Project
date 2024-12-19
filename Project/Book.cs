using System;
using System.Collections.Generic;

namespace Project
{
    public class Book
    {
        private string _title;
        private List<Author> _authors;
        private GenreType _genre;
        private int _totalCopies;
        private int _availableCopies;

        /// <summary>
        /// Назва книги
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Назва книги не може бути порожньою або містити лише пробіли.");
                _title = value;
            }
        }

        /// <summary>
        /// Список авторів книги
        /// </summary>
        public List<Author> Authors
        {
            get => _authors;
            set
            {
                if (value == null || value.Count == 0)
                    throw new ArgumentException("У книги повинен бути хоча б один автор.");
                _authors = value;
            }
        }

        /// <summary>
        /// Жанр книги
        /// </summary>
        public GenreType Genre
        {
            get => _genre;
            set
            {
                if (!Enum.IsDefined(typeof(GenreType), value))
                {
                    throw new ArgumentException("Невірний жанр. Допустимі значення: від 0 до 9.", nameof(value));
                }
                _genre = value;
            }
        }

        /// <summary>
        /// Загальна кількість копій книги
        /// </summary>
        public int TotalCopies
        {
            get => _totalCopies;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Загальна кількість копій не може бути від'ємною.");
                _totalCopies = value;

                if (_availableCopies > _totalCopies)
                    _availableCopies = _totalCopies;
            }
        }

        /// <summary>
        /// Кількість доступних копій для позики
        /// </summary>
        public int AvailableCopies
        {
            get => _availableCopies;
            set
            {
                if (value < 0 || value > TotalCopies)
                    throw new ArgumentOutOfRangeException("Кількість доступних копій має бути в межах від 0 до TotalCopies.");
                _availableCopies = value;
            }
        }

        /// <summary>
        /// Конструктор класу Book.
        /// </summary>
        public Book(string title, List<Author> authors, GenreType genre, int totalCopies)
        {
            Title = title;
            Authors = authors ?? new List<Author>();
            Genre = genre;
            TotalCopies = totalCopies;
            AvailableCopies = totalCopies;
        }

        /// <summary>
        /// Виведення інформації про книгу.
        /// </summary>
        public string DisplayInfo()
        {
            var sortedAuthors = new List<Author>(Authors);
            sortedAuthors.Sort();
            return $"Назва: {Title}, Жанр: {Genre}, " +
                   $"Автори: {string.Join(", ", sortedAuthors)}, " +
                   $"Загальна кількість копій: {TotalCopies}, Доступна кількість копій: {AvailableCopies}";
        }
    }
}
