using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp.BookStore.Models;
using WebApp.BookStore.Repository;

namespace WebApp.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _BookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _IWebHostEnvironment = null;

        public BookController(BookRepository bookRepository, LanguageRepository languageRepository, IWebHostEnvironment IWebHostEnvironment)
        {
            _BookRepository =bookRepository;
            _languageRepository = languageRepository;
            _IWebHostEnvironment = IWebHostEnvironment;
        }
        public async Task<ViewResult>  GetAllBooks()
        {
        var data = await  _BookRepository.GetAllBooks();
            return View(data);
        }

        //[Route("BookDetails/{id}", Name = "BookDetailRoute")]
        public async Task<ViewResult> GetBooksById(int id)
        {
            
            var data =await  _BookRepository.GetBookById(id);

            return View(data);
        }
        public List<BookModel> SearchBooks(string title,string authorname)
        {
            return _BookRepository.SearchBook(title,authorname);
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId =0)
        {

       ViewBag.Language =   new SelectList(await _languageRepository.GetLanguages(),"Id","Name");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string folder = "book/cover/";
                    folder += Guid.NewGuid().ToString() + "_"+ bookModel.CoverPhoto.FileName;

                    bookModel.CoverImageUrl ="/" +folder;

                    string serverFolder = Path.Combine(_IWebHostEnvironment.WebRootPath, folder);

                 await bookModel.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                int id = await _BookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }

            }

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");




            return View();
        }
    }
}
