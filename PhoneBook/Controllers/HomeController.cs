using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using System.Diagnostics;

namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        
            private PhoneBookContext context { get; set; }
            public HomeController(PhoneBookContext ctx)
            {
                context = ctx;
            }
            public IActionResult Index()
            {
                var phoneBooks = context.PhoneBooks.OrderBy(m => m.Name).ToList(); 
            return View(phoneBooks);
            }
        
    }
}