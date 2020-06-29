using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChildDictionary.Models;

namespace ChildDictionary.Controllers
{
    public class HomeController : Controller
    {
        private readonly Data.ChildDictionaryContext _context;

        public HomeController(Data.ChildDictionaryContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string SearchString, string Language)
        {
            Models.Words word;
            if(Language == "0")
            {
                word = _context.Words.Where(x => x.WordTurkish == SearchString).SingleOrDefault();
            }
            else
            {
                word = _context.Words.Where(x => x.WordEnglish == SearchString).SingleOrDefault();
            }
            if (word == null)
            {
                TempData["Error"] = "Nothing found.";
                return View();
            }
            return View(word);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
