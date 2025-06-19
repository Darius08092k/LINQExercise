using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using LINQExercise.Repos;
using Microsoft.Data.SqlClient;

namespace LINQExercise
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ITableRepo repo = new TableRepo();
            var Exercise = new Exercise(repo);
            Console.WriteLine("Ex 1:");
            Exercise.AdultPeople();
            Console.WriteLine("Ex 2:");
            Exercise.BookTitles();
            Console.WriteLine("Ex 3:");
            Exercise.orderedAuthors();
            Console.WriteLine("Ex 4:");
            Exercise.booksWithSpecificTitle("Harry");
            Console.WriteLine("Ex 5:");
            Exercise.printPeopleNamesAndAges();
            Console.WriteLine("Ex 6:");
            Exercise.groupedBooksByAuthor();
            Console.WriteLine("Ex 7:");
            Exercise.countedBooksByGenre();
            Console.WriteLine("Ex 8:");
            Exercise.bookNameAuthorGenre();
            Console.WriteLine("Ex 9:");
            Exercise.booksWithPublisher();
            Console.WriteLine("Ex 10:");
            Exercise.peopleWithAtLeastOneBook();
            Console.WriteLine("Ex 11:");
            Exercise.booksOnLoan();
            Console.WriteLine("Ex 12:");
            Exercise.borrowedBooksWithAuthorAndPerson();
            Console.WriteLine("Ex 13:");
            Exercise.authorsWithBooks();
            Console.WriteLine("Ex 14:");
            Exercise.personWithNrOfBooks();
            Console.WriteLine("Ex 15:");
            Exercise.neverBorrowedBooks();
            Console.WriteLine("Ex 16:");
            Exercise.publishersWithAtLeastTwoBooks();
            Console.WriteLine("Ex 17:");
            Exercise.averageAgePerBook();
            Console.WriteLine("Ex 18:");
            Exercise.booksAndNrOfBurrows();
        }
    }
}

