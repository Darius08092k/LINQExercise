using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExercise.Repos
{
    public interface ITableRepo
    {
            List<Author> GetAuthors();
            List<Book> GetBooks();
            List<Genre> GetGenres();
            List<Publisher> GetPublishers();
            List<People> GetPeople();
            List<Loan> GetLoans();

    }
}
