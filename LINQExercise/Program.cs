using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.Data.SqlClient;

namespace LINQExercise
{
    internal class Program
    {

        static void Main(string[] args)
        {
            TableRepo repo = new TableRepo();
            Console.WriteLine("Ex 1:");
            repo.AdultPeople();
            Console.WriteLine("Ex 2:");
            repo.BookTitles();
            Console.WriteLine("Ex 3:");
            repo.orderedAuthors();
            Console.WriteLine("Ex 4:");
            repo.booksWithSpecificTitle("Harry");
            Console.WriteLine("Ex 5:");
            repo.printPeopleNamesAndAges();
            Console.WriteLine("Ex 6:");
            repo.groupedBooksByAuthor();
            Console.WriteLine("Ex 7:");
            repo.countedBooksByGenre();
            Console.WriteLine("Ex 8:");
            repo.bookNameAuthorGenre();
            Console.WriteLine("Ex 9:");
            repo.booksWithPublisher();
            Console.WriteLine("Ex 10:");
            repo.peopleWithAtLeastOneBook();
            Console.WriteLine("Ex 11:");
            repo.booksOnLoan();
            Console.WriteLine("Ex 12:");
            repo.borrowedBooksWithAuthorAndPerson();
            Console.WriteLine("Ex 13:");
            repo.authorsWithBooks();
            Console.WriteLine("Ex 14:");
            repo.personWithNrOfBooks();
            Console.WriteLine("Ex 15:");
            repo.neverBorrowedBooks();
            Console.WriteLine("Ex 16:");
            repo.publishersWithAtLeastTwoBooks();
            Console.WriteLine("Ex 17:");
            repo.averageAgePerBook();
            Console.WriteLine("Ex 18:");
            repo.booksAndNrOfBurrows();
        }
    }
}

