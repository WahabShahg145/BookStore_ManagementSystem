using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.BookStore.Models;
using System.Dynamic;

namespace WebApp.BookStore.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult About()
        {
           
            return View();
        }
        public ViewResult Contact()
        {
            
            return View();
        }

    }
}
