using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.BookStore.Data;
using WebApp.BookStore.Models;

namespace WebApp.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                Title= model.Title,
                CreatedOn = DateTime.UtcNow,
                LanguageId=model.LanguageId,
                Pages =model.Pages.HasValue ? model.Pages.Value:0,
                Description=model.Description,
                UpdatedOn=DateTime.UtcNow,
                CoverImageUrl=model.CoverImageUrl
                
            };
          await _context.Books.AddAsync(newBook);
          await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
                 .Select(book => new BookModel()
                 {
                     Author = book.Author,
                     Category = book.Category,
                     Description = book.Description,
                     Id = book.Id,
                     LanguageId = book.LanguageId,
                     Language = book.Language.Name,
                     Title = book.Title,
                     Pages = book.Pages,
                     CoverImageUrl=book.CoverImageUrl
                 }).ToListAsync();

        }
        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Title = book.Title,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Pages = book.Pages,
                    CoverImageUrl=book.CoverImageUrl




                }).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }

        
    }
}
