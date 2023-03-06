using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projet_EBook.Data;
using Projet_EBook.Models;

namespace Projet_EBook.Controllers
{
    public class EBooksController : Controller
    {
        private readonly EbookDBContext _context;

        public EBooksController(EbookDBContext context)
        {
            _context = context;
        }

        // GET: EBooks
        public async Task<IActionResult> Index()
        {
              return View(await _context.Ebooks.ToListAsync());
        }

        // GET: EBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ebooks == null)
            {
                return NotFound();
            }

            var eBook = await _context.Ebooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eBook == null)
            {
                return NotFound();
            }

            return View(eBook);
        }

        // GET: EBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,auteur,Description,prix,DisplayOrder,CreatedDateTime")] EBook eBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eBook);
        }

        // GET: EBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ebooks == null)
            {
                return NotFound();
            }

            var eBook = await _context.Ebooks.FindAsync(id);
            if (eBook == null)
            {
                return NotFound();
            }
            return View(eBook);
        }

        // POST: EBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,auteur,Description,prix,DisplayOrder,CreatedDateTime")] EBook eBook)
        {
            if (id != eBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EBookExists(eBook.Id))
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
            return View(eBook);
        }

        // GET: EBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ebooks == null)
            {
                return NotFound();
            }

            var eBook = await _context.Ebooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eBook == null)
            {
                return NotFound();
            }

            return View(eBook);
        }

        // POST: EBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ebooks == null)
            {
                return Problem("Entity set 'EbookDBContext.Ebooks'  is null.");
            }
            var eBook = await _context.Ebooks.FindAsync(id);
            if (eBook != null)
            {
                _context.Ebooks.Remove(eBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EBookExists(int id)
        {
          return _context.Ebooks.Any(e => e.Id == id);
        }
    }
}
