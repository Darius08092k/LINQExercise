using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LINQExercise.Repos
{
    public class Exercise
    {
        private readonly ITableRepo _tableRepo;

        public Exercise(ITableRepo tableRepository)
        {
            _tableRepo = tableRepository;
        }
        public void AdultPeople()
        {
            var People = _tableRepo.GetPeople();
            var adutPeope = from person in People
                            where person.Age >= 18
                            select person;

            foreach (var item in adutPeope)
            {
                Console.WriteLine($"{item.LastName} age: {item.Age}");
            }
        }

        public void BookTitles()
        {
            var Books = _tableRepo.GetBooks();

            var bookTitles = from book in Books
                             select book.Title;


            foreach (var item in bookTitles)
            {
                Console.WriteLine($"Title: {item}");
            }
        }
        public void orderedAuthors()
        {
            var Authors = _tableRepo.GetAuthors();

            var orderedAuthors = from author in Authors
                                 orderby author.Name
                                 select author;
            foreach (var item in orderedAuthors)
            {
                Console.WriteLine($"Author: {item.Name}");
            }
        }

        public void booksWithSpecificTitle(string value)
        {
            var Books = _tableRepo.GetBooks();


            var booksWithTitle = from book in Books
                                 where book.Title.Contains(value)
                                 select book;

            foreach (var item in booksWithTitle)
            {
                Console.WriteLine($"Books: {item.Title}");
            }
        }
        public void printPeopleNamesAndAges()
        {
            var People = _tableRepo.GetPeople();


            var peopleProjection = from person in People
                                   select new
                                   {
                                       FullName = person.FirstName + " " + person.LastName,
                                       Age = person.Age
                                   };


            foreach (var person in peopleProjection)
            {
                Console.WriteLine($"{person.FullName}, Age: {person.Age}");
            }
        }
        public void groupedBooksByAuthor()
        {
            var Books = _tableRepo.GetBooks();
            var Authors = _tableRepo.GetAuthors();

            var groupedBooks = from book in Books
                               join author in Authors
                               on book.AuthorId equals author.Id
                               group book by author.Name into bookGroup
                               select new
                               {
                                   AuthorName = bookGroup.Key,
                                   Books = bookGroup
                               };
            foreach (var group in groupedBooks)
            {
                Console.WriteLine($"Author: {group.AuthorName}");
                foreach (var book in group.Books)
                {
                    Console.WriteLine($"  - {book.Title}");
                }
            }
        }
        public void countedBooksByGenre()
        {
            var Books = _tableRepo.GetBooks();
            var Genres = _tableRepo.GetGenres();

            var countedBooks = from book in Books
                               join genre in Genres
                               on book.GenreId equals genre.Id
                               group book by genre.Name into bookGroup
                               select new
                               {
                                   GenreName = bookGroup.Key,
                                   Count = bookGroup.Count()
                               };

            foreach (var group in countedBooks)
            {
                Console.WriteLine($"Genre: {group.GenreName}, Count: {group.Count}");
            }
        }

        public void bookNameAuthorGenre()
        {
            var Books = _tableRepo.GetBooks();
            var Genres = _tableRepo.GetGenres();
            var Authors = _tableRepo.GetAuthors();

            var bookWithAuthorAndGenre = from book in Books
                                         join author in Authors on book.AuthorId equals author.Id
                                         join genre in Genres on book.GenreId equals genre.Id
                                         select new
                                         {
                                             BookTitle = book.Title,
                                             AuthorName = author.Name,
                                             GenreName = genre.Name
                                         };



            foreach (var item in bookWithAuthorAndGenre)
            {
                Console.WriteLine($"\"{item.BookTitle}\" by {item.AuthorName} - Genre: {item.GenreName}");
            }
        }

        public void booksWithPublisher()
        {
            var Books = _tableRepo.GetBooks();
            var Publishers = _tableRepo.GetPublishers();

            var booksWithPublisher = from book in Books
                                     join publisher in Publishers on book.PublisherId equals publisher.Id
                                     select new
                                     {
                                         BookTitle = book.Title,
                                         PublisherName = publisher.Name
                                     };
            foreach (var item in booksWithPublisher)
            {
                Console.WriteLine($"\"{item.BookTitle}\" published by {item.PublisherName}");
            }
        }

        public void peopleWithAtLeastOneBook()
        {
            var Books = _tableRepo.GetBooks();
            var People = _tableRepo.GetPeople();
            var Loans = _tableRepo.GetLoans();

            var poleWithBooks = from person in People
                                join loan in Loans on person.Id equals loan.PersonId
                                join book in Books on loan.BookId equals book.Id
                                group loan by new { person.FirstName, person.LastName } into personGroup
                                select new
                                {
                                    FullName = personGroup.Key.FirstName + " " + personGroup.Key.LastName,
                                    BookCount = personGroup.Count()
                                };
            foreach (var person in poleWithBooks)
            {
                Console.WriteLine($"{person.FullName} borrowed {person.BookCount} book(s)");
            }
        }

        public void booksOnLoan()
        {
            var Books = _tableRepo.GetBooks();
            var People = _tableRepo.GetPeople();
            var Loans = _tableRepo.GetLoans();

            var booksOnLoan = from book in Books
                              join loan in Loans on book.Id equals loan.BookId
                              join person in People on loan.PersonId equals person.Id
                              where loan.ReturnDate == null
                              select new
                              {
                                  BookTitle = book.Title,
                                  Person = person.FirstName + " " + person.LastName,
                              };
            foreach (var item in booksOnLoan)
            {
                Console.WriteLine($"\"{item.BookTitle}\" is currently on loan by {item.Person}");
            }
        }
        public void borrowedBooksWithAuthorAndPerson()
        {
            var Books = _tableRepo.GetBooks();
            var People = _tableRepo.GetPeople();
            var Loans = _tableRepo.GetLoans();
            var Authors = _tableRepo.GetAuthors();


            var borrowedBooks = from loan in Loans
                                join book in Books on loan.BookId equals book.Id
                                join person in People on loan.PersonId equals person.Id
                                join author in Authors on book.AuthorId equals author.Id
                                select new
                                {
                                    bookTitle = book.Title,
                                    authorName = author.Name,
                                    borrower = person.FirstName + " " + person.LastName,
                                };
            foreach (var item in borrowedBooks)
            {
                Console.WriteLine($"\"{item.bookTitle}\" by {item.authorName} is borrowed by {item.borrower}");
            }
        }
        public void authorsWithBooks()
        {
            var Books = _tableRepo.GetBooks();
            var Authors = _tableRepo.GetAuthors();

            var authorsWithBooks = from author in Authors
                                   join book in Books on author.Id equals book.AuthorId
                                   group book by author.Name into bookGroup
                                   select new
                                   {
                                       authorName = bookGroup.Key,
                                       bookCount = bookGroup.Count(),
                                   };
            foreach (var item in authorsWithBooks)
            {
                Console.WriteLine($"{item.authorName} wrote \"{item.bookCount}\" book(s)");
            }
        }
        public void personWithNrOfBooks()
        {
            var People = _tableRepo.GetPeople();
            var Loans = _tableRepo.GetLoans();

            var personWithBooks = from person in People
                                  join loan in Loans on person.Id equals loan.PersonId
                                  group loan by new { person.FirstName, person.LastName } into personGroup
                                  select new
                                  {
                                      fullNmae = personGroup.Key.FirstName + " " + personGroup.Key.LastName,
                                      borrowedBooks = personGroup.Count()
                                  };
            foreach (var item in personWithBooks)
            {
                Console.WriteLine($"{item.fullNmae} has borrowed {item.borrowedBooks} book(s)");
            }
        }

        public void neverBorrowedBooks()
        {
            var Books = _tableRepo.GetBooks();
            var Loans = _tableRepo.GetLoans();

            var neverBorrowedBooks = from book in Books
                                     where !(from loan in Loans
                                             select loan.BookId).Contains(book.Id)
                                     select book;
            foreach (var item in neverBorrowedBooks)
            {
                Console.WriteLine($"\"{item.Title}\" has never been borrowed");
            }
        }

        public void publishersWithAtLeastTwoBooks()
        {
            var Books = _tableRepo.GetBooks();
            var Publishers = _tableRepo.GetPublishers();

            var publishersWithTwoBooks = from book in Books
                                         join publisher in Publishers on book.PublisherId equals publisher.Id
                                         group book by publisher.Name into bookGroup
                                         where bookGroup.Count() >= 2
                                         select new
                                         {
                                             PublisherName = bookGroup.Key,
                                             BookCount = bookGroup.Count()
                                         };
            foreach (var item in publishersWithTwoBooks)
            {
                Console.WriteLine($"{item.PublisherName} has published {item.BookCount} book(s)");
            }
        }

        public void averageAgePerBook()
        {
            var Books = _tableRepo.GetBooks();
            var People = _tableRepo.GetPeople();
            var Loans = _tableRepo.GetLoans();

            var averageAge = from person in People
                             join loan in Loans on person.Id equals loan.PersonId
                             join book in Books on loan.BookId equals book.Id
                             group person by new { book.Title, book.Id } into bookGroup
                             select new
                             {
                                 BookTitle = bookGroup.Key.Title,
                                 AverageAge = bookGroup.Average(person => person.Age)
                             };
            foreach (var item in averageAge)
            {
                Console.WriteLine($"The average age of people who borrowed \"{item.BookTitle}\" is {item.AverageAge} years");
            }
        }

        public void booksAndNrOfBurrows()
        {
            var Books = _tableRepo.GetBooks();
            var Loans = _tableRepo.GetLoans();

            var booksAndBurrows = from book in Books
                                  join loan in Loans on book.Id equals loan.BookId
                                  group loan by book.Title into bookGroup
                                  select new
                                  {
                                      bookTitile = bookGroup.Key,
                                      borrowsCount = bookGroup.Count()
                                  };
            foreach (var item in booksAndBurrows)
            {
                Console.WriteLine($"\"{item.bookTitile}\" has been borrowed {item.borrowsCount} time(s)");
            }
        }
    }
}
