using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Project
{
    public class Author : Person, IComparable<Author>
    {
        private string _name;

        /// <summary>
        /// Ім'я автора. Може містити лише букви.
        /// </summary>
        public override string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Ім’я не може бути null, пустим або пробілом.", nameof(value));
                }
                if (!Regex.IsMatch(value, @"^[a-zA-Zа-яА-ЯїЇєЄіІ' .]+$"))
                {
                    throw new ArgumentException("Ім'я може містити лише літери та пробіли.", nameof(value));
                }
                _name = value;
            }
        }

        /// <summary>
        /// Конструктор для створення автора.
        /// </summary>
        public Author(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Порівнює авторів за іменем.
        /// </summary>
        /// <param name="other">Інший об'єкт Author для порівняння.</param>
        /// <returns>
        /// Додатне значення, якщо поточне ім'я більше; від'ємне значення, якщо менше;
        /// нуль, якщо імена однакові.
        /// </returns>
        public int CompareTo(Author other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Повертає текстове представлення об'єкта Author.
        /// </summary>
        public override string ToString()
        {
            return $"Автор: {Name}";
        }
    }
}
