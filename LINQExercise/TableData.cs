using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExercise
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class People
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class Loan
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public int PersonId { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

    class TableData
    {
      
    }
}
