using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.BookStore.Data;
using WebApp.BookStore.Models;

namespace WebApp.BookStore.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _context = null;

        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Description=x.Description,
                Name=x.Name
            }).ToListAsync();
        }

    }
}
