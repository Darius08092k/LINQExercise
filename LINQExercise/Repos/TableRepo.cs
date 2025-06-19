using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using LINQExercise.Repos;
using Microsoft.Data.SqlClient;


namespace LINQExercise
{

    internal class TableRepo:ITableRepo
    {
        private const string _connectionString = "Data Source=DARIUS-PC\\SQLTUTORIAL;Initial Catalog=TutorialsDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public List<Author> GetAuthors()
        {
            var list = new List<Author>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, Name FROM Authors", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Author
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }
            return list;
        }

        public List<Book> GetBooks()
        {
            var list = new List<Book>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, Title, AuthorId, GenreId, PublisherId FROM Books", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Book
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        AuthorId = reader.GetInt32(2),
                        GenreId = reader.GetInt32(3),
                        PublisherId = reader.GetInt32(4)
                    });
                }
            }
            return list;
        }

        public List<Genre> GetGenres()
        {
            var list = new List<Genre>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, Name FROM Genres", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Genre
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }
            return list;
        }

        public List<Publisher> GetPublishers()
        {
            var list = new List<Publisher>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, Name FROM Publishers", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Publisher
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }
            return list;
        }

        public List<People> GetPeople()
        {
            var list = new List<People>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, FirstName, LastName, Age FROM People", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new People
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Age = reader.GetInt32(3)
                    });
                }
            }
            return list;
        }

        public List<Loan> GetLoans()
        {
            var list = new List<Loan>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id, BookId, PersonId, LoanDate, ReturnDate FROM Loans", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Loan
                    {
                        Id = reader.GetInt32(0),
                        BookId = reader.GetInt32(1),
                        PersonId = reader.GetInt32(2),
                        LoanDate = reader.GetDateTime(3),
                        ReturnDate = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4)
                    });
                }
            }
            return list;
        }
    }
}
