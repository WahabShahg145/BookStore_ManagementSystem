using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.BookStore.Models;
using WebApp.BookStore.Repository;

namespace WebApp.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _BookRepository = null;

     public BookController()
        {
            _BookRepository =new  BookRepository();
        }
        public ViewResult  GetAllBooks()
        {
        var data =  _BookRepository.GetAllBooks();

            return View(data);
        }
        public ViewResult GetBooksById(int id)
        {
            var data =  _BookRepository.GetBookById(id);

            return View(data);
        }
        public List<BookModel> SearchBooks(string title,string authorname)
        {
            return _BookRepository.SearchBook(title,authorname);
        }
    }
}
