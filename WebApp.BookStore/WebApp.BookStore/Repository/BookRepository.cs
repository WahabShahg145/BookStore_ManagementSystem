using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.BookStore.Models;

namespace WebApp.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains( title) || x.Author.Contains( authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,Title="C#",Author="Wahab",Description="Books description",Category="Action",Pages=12,Language="English" },
                new BookModel() { Id = 2, Title = "Java", Author = "Wahab",Description="Books description",Category="Strategy",Pages=15,Language="English" },
                new BookModel(){Id=3,Title="C++",Author="Wahab",Description="Books description",Category="Film",Pages=120,Language="English" },
                new BookModel(){Id=4,Title=".Net",Author="Wahab",Description="Books description",Category="Drama",Pages=1212,Language="English" },
                new BookModel(){Id=5,Title="Core",Author="Wahab",Description="Books description",Category="Action",Pages=111,Language="English" }
            };
        }
    }
}
