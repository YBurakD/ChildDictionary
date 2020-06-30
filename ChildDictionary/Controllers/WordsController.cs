using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChildDictionary.Data;
using ChildDictionary.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using ChildDictionary.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace ChildDictionary.Controllers
{
    public class WordsController : Controller
    {
        private readonly ChildDictionaryContext _context;

        public WordsController(ChildDictionaryContext context)
        {
            _context = context;
        }

        // GET: Words
        //[Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Words.ToListAsync());
        }

        //[Authorize(Roles = "Teacher")]
        // GET: Words/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var words = await _context.Words
                .FirstOrDefaultAsync(m => m.Id == id);
            if (words == null)
            {
                return NotFound();
            }

            return View(words);
        }
        //[Authorize(Roles = "Teacher")]
        // GET: Words/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Words/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Create(WordsViewModel words)
        {
            if (ModelState.IsValid)
            {
                var image = words.Image;
                if (image != null && image.Length > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\WordImg", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileSteam);
                    }

                    words.ImagePath = fileName;
                }
                Words word = new Words
                {
                    WordEnglish = words.WordEnglish,
                    WordTurkish = words.WordTurkish,
                    ImagePath = words.ImagePath,
                    Meaning = words.Meaning
                };
                _context.Add(word);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(words);
        }

        // GET: Words/Edit/5
        //[Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var words = await _context.Words.FindAsync(id);
            if (words == null)
            {
                return NotFound();
            }
            var word = new ViewModels.WordsViewModel
            {
                Id = words.Id,
                WordTurkish = words.WordTurkish,
                WordEnglish = words.WordEnglish,
                Meaning = words.Meaning,
                ImagePath = words.ImagePath
            };
            return View(word);
        }

        // POST: Words/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int id, WordsViewModel words)
        {
            if (id != words.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var word = new Words
                {
                    Id = words.Id,
                    WordEnglish = words.WordEnglish,
                    WordTurkish = words.WordTurkish,
                    Meaning = words.Meaning
                };
                var pathFromTable = await _context.Words
                .Where(b => b.Id == id)
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.ImagePath
                })
                .ToListAsync();
                var oldPath = pathFromTable[0].Text;
                if (words.Image != null)
                {
                    var image = words.Image;
                    var fileName = Path.GetFileName(image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\WordImg", fileName);
                    word.ImagePath = fileName;
                    if (fileName != oldPath && oldPath != null)
                    {
                        using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(fileSteam);
                        }
                        oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\WordImg", oldPath);
                        System.IO.File.Delete(oldPath);
                    }
                    
                }
                else
                    word.ImagePath = oldPath;
                try
                {
                    _context.Update(word);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WordsExists(words.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(words);
        }

        // GET: Words/Delete/5
        //[Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var words = await _context.Words
                .FirstOrDefaultAsync(m => m.Id == id);
            if (words == null)
            {
                return NotFound();
            }

            return View(words);
        }

        // POST: Words/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var words = await _context.Words.FindAsync(id);
            var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\WordImg", words.ImagePath);
            System.IO.File.Delete(oldPath);
            _context.Words.Remove(words);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WordsExists(int id)
        {
            return _context.Words.Any(e => e.Id == id);
        }
    }
}
