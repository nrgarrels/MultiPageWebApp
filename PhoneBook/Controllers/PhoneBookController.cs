using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;

namespace PhoneBookController.Controllers
{
    public class PhoneBookController : Controller
    {
        private PhoneBookContext context { get; set; }
        public PhoneBookController(PhoneBookContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new PhoneBookModel());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit"; 
            var phoneBook = context.PhoneBooks.Find(id); 
            return View(phoneBook);
        }
        [HttpPost]
        public IActionResult Edit(PhoneBookModel phoneBook)
        {
            if (ModelState.IsValid)
            {
                if (phoneBook.PhoneBookId == 0) context.PhoneBooks.Add(phoneBook);
                else
                    context.PhoneBooks.Update(phoneBook); context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (phoneBook.PhoneBookId == 0) ? "Add" : "Edit"; 
                return View(phoneBook);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var phoneBook = context.PhoneBooks.Find(id); return View(phoneBook);
        }
        [HttpPost]
        public IActionResult Delete(PhoneBookModel phoneBook)
        {
            context.PhoneBooks.Remove(phoneBook); context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}