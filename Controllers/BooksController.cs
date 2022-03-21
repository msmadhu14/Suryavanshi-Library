using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuryavanshiLibrary.Data;
using SuryavanshiLibrary.Models;

namespace SuryavanshiLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryDbContext _context;

        public BooksController(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> BookManagement()
        {
            return View(await _context.Books.ToListAsync());
        }

        public async Task<IActionResult> IndexEdit()
        {
            var libraryDbContext = _context.Books.Include(b => b.Author).Include(b => b.Publisher);
            return View(await libraryDbContext.ToListAsync());
        }
        public async Task<IActionResult> IndexDelete()
        {
            var libraryDbContext = _context.Books.Include(b => b.Author).Include(b => b.Publisher);
            return View(await libraryDbContext.ToListAsync());
        }
        // GET: Books
        public async Task<IActionResult> Index()
        {
            var libraryDbContext = _context.Books.Include(b => b.Author).Include(b => b.Publisher);
            return View(await libraryDbContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "ID", "Name");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "ID", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISBN,Title,PublisherId,AuthorId,IssuedStatus,IsDeleted")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "ID", "Name", book.AuthorId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "ID", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "ID", "Name", book.AuthorId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "ID", "Name", book.PublisherId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ISBN,Title,PublisherId,AuthorId,IssuedStatus,IsDeleted")] Book book)
        {
            if (id != book.ISBN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.ISBN))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "ID", "Name", book.AuthorId);
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "ID", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(string id)
        {
            return _context.Books.Any(e => e.ISBN == id);
        }

        public IActionResult Search(string SearchBook, string search)
        {

            if (SearchBook == "ISBN")
                return View(_context.Books.Where(result => result.ISBN == search || search == null).ToList());
            else if (SearchBook == "AuthorId")
                return View(_context.Books.Where(result => result.AuthorId == search || search == null).ToList());
            else if (SearchBook == "PublisherId")
                return View(_context.Books.Where(result => result.PublisherId == search || search == null).ToList());
            else
                return View(_context.Books.Where(result => result.Title.StartsWith(search) || search == null).ToList());

        }
    }
}
