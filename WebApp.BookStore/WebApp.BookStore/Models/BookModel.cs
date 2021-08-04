using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApp.BookStore.Enums;
using WebApp.BookStore.Data;

namespace WebApp.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please Enter Author")]
        public string Author { get; set; }

        public string Category { get; set; }
        [Required(ErrorMessage ="Please Enter the Number of Pages")]
        
        public int? Pages { get; set; }

        [Required(ErrorMessage ="Please Choose your Language")]
        public int LanguageId { get; set; }

        public string Language { get; set; }

        [StringLength(300,MinimumLength =20,ErrorMessage ="Enter required length of description")]
        public string Description { get; set; }


       

    }
}
