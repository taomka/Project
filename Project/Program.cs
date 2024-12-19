using System.Text;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Library library = new Library();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Меню Бібліотеки ---");
                Console.WriteLine("1. Додати книгу");
                Console.WriteLine("2. Переглянути інвентар бібліотеки");
                Console.WriteLine("3. Зареєструвати читача до бібліотеки");
                Console.WriteLine("4. Переглянути список читачів");
                Console.WriteLine("5. Позичити книгу");
                Console.WriteLine("6. Повернути книгу");
                Console.WriteLine("7. Переглянути журнал позик");
                Console.WriteLine("8. Вихід");
                Console.Write("Виберіть опцію: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddBookToLibrary(library);
                        break;
                    case "2":
                        ViewLibraryInventory(library);
                        break;
                    case "3":
                        RegistReader(library);
                        break;
                    case "4":
                        ViewLibraryReaders(library);
                        break;
                    case "5":
                        BorrowBookFromLibrary(library);
                        break;
                    case "6":
                        ReturnBookToLibrary(library);
                        break;
                    case "7":
                        ViewBorrowedBooksLog(library);
                        break;
                    case "8":
                        exit = true;
                        Console.WriteLine("Дякуємо за використання бібліотеки!");
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void RegistReader(Library library)
        {
            Console.Write("Введіть ім'я читача: ");
            string readerName = Console.ReadLine();

            Reader reader = new Reader(readerName);
            library.AddReader(reader);
            Console.WriteLine($"Читач з ім'ям '{readerName}' успішно додан.");
        }

        static void ViewLibraryReaders(Library library)
        {
            if (library.Readers.Count == 0) Console.WriteLine("Читачів немає.");
            else
            {
                foreach (Reader reader in library.Readers.Order())
                {
                    Console.WriteLine(reader);
                }
            }
        }

        static void AddBookToLibrary(Library library)
        {
            try
            {
                Console.Write("Введіть назву книги: ");
                string title = Console.ReadLine();

                var existingEntry = library.BookInventory.FirstOrDefault(entry => entry.Book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                if (existingEntry != null)
                {
                    Console.WriteLine("Книга з такою назвою вже є, збільшуємо кількість копій.");
                    Console.Write("Введіть кількість копій для додавання: ");
                    if (!int.TryParse(Console.ReadLine(), out int additionalCopies) || additionalCopies <= 0)
                    {
                        Console.WriteLine("Кількість має бути числом більше нуля. Операцію скасовано.");
                        return;
                    }

                    existingEntry.Quantity += additionalCopies;
                    existingEntry.Book.TotalCopies += additionalCopies;
                    existingEntry.Book.AvailableCopies += additionalCopies;
                    Console.WriteLine($"Кількість копій книги '{title}' успішно збільшено на {additionalCopies}.");
                    return;
                }

                Console.Write("Введіть жанр книги (0 - Художня література, 1 - Нехудожня література, 2 - Детектив, 3 - Фантастика,\n 4 - Наукова фантастика, 5 - Біографія, 6 - Історія, 7 - Романтика, 8 - Трилер, 9 - Дитяча література):\n");
                if (!int.TryParse(Console.ReadLine(), out int genreValue) || !Enum.IsDefined(typeof(GenreType), genreValue))
                {
                    Console.WriteLine("Невірний жанр. Введіть число від 0 до 9.");
                    return;
                }

                Console.Write("Введіть кількість копій: ");
                if (!int.TryParse(Console.ReadLine(), out int copies) || copies <= 0)
                {
                    Console.WriteLine("Кількість має бути числом більше нуля. Операцію скасовано.");
                    return;
                }

                Console.Write("Скільки авторів у книги? ");
                if (!int.TryParse(Console.ReadLine(), out int authorCount) || authorCount <= 0)
                {
                    Console.WriteLine("Книга повинна мати хоча б одного автора. Операцію скасовано.");
                    return;
                }

                var authors = new List<Author>();
                for (int i = 0; i < authorCount; i++)
                {
                    Console.Write($"Введіть ім'я автора {i + 1}: ");
                    string authorName = Console.ReadLine();
                    authors.Add(new Author(authorName));
                }

                var book = new Book(title, authors, (GenreType)genreValue, copies);
                library.AddBook(book, copies);

                Console.WriteLine($"Книга '{title}' успішно додана до бібліотеки.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        static void ViewLibraryInventory(Library library)
        {
            Console.WriteLine("\n--- Інвентар бібліотеки ---");
            if (library.BookInventory.Count == 0)
            {
                Console.WriteLine("Бібліотека порожня.");
                return;
            }

            foreach (var entry in library.BookInventory)
            {
                Console.WriteLine(entry.Book.DisplayInfo());
            }
        }

        static void BorrowBookFromLibrary(Library library)
        {
            try
            {
                Console.Write("Введіть назву книги: ");
                string title = Console.ReadLine();

                var book = library.BookInventory.Find(entry => entry.Book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))?.Book;
                if (book == null)
                {
                    Console.WriteLine("Книга з такою назвою не знайдена.");
                    return;
                }

                Console.Write("Введіть ID читача: ");
                long readerId = long.Parse(Console.ReadLine());



                Console.Write("Введіть кількість днів для позики: ");
                if (!int.TryParse(Console.ReadLine(), out int period) || period <= 0)
                {
                    Console.WriteLine("Період має бути числом більше нуля. Операцію скасовано.");
                    return;
                }

                var reader = library.FindReader(readerId);
                if (reader == null)
                    throw new Exception("Читача не знайдено.");
                library.LendBook(book, reader, period);
                Console.WriteLine($"Книга '{book.Title}' успішно позичена читачем {reader.Name}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        static void ReturnBookToLibrary(Library library)
        {
            try
            {
                Console.Write("Введіть назву книги: ");
                string title = Console.ReadLine();

                var book = library.BookInventory.FirstOrDefault(entry => entry.Book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))?.Book;
                if (book == null)
                {
                    Console.WriteLine("Книга з такою назвою не знайдена.");
                    return;
                }

                Console.Write("Введіть ID читача: ");
                long readerId = long.Parse(Console.ReadLine());

                var reader = library.BorrowedBooksLog.FirstOrDefault(entry => entry.Book.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && entry.Reader.Id == readerId)?.Reader;
                if (reader == null)
                {
                    Console.WriteLine("Цей читач не позичав цю книгу.");
                    return;
                }

                Console.Write("Чи була книга повернена вчасно? (так/ні): ");
                string response = Console.ReadLine();
                bool isReturnedOnTime = response?.Trim().ToLower() == "так";

                var resultMessage = library.ReturnBook(book, reader, isReturnedOnTime);
                Console.WriteLine(resultMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        static void ViewBorrowedBooksLog(Library library)
        {
            Console.WriteLine("\n--- Журнал позик ---");
            var log = library.GetBorrowedBooksLog();
            if (log.Count == 0)
            {
                Console.WriteLine("Журнал позик порожній.");
                return;
            }

            foreach (var line in log)
            {
                Console.WriteLine(line);
            }
        }
    }
}
