using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EseLibriIdentity.Data;
using EseLibriIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using ReflectionIT.Mvc.Paging;

namespace EseLibriIdentity.Views
{
    public class LibriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibriController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Libri
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Libri.Include(l => l.Autore).Include(l => l.Editore);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Libri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libri == null)
            {
                return NotFound();
            }

            var libro = await _context.Libri
                .Include(l => l.Autore)
                .Include(l => l.Editore)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libri/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["IdAutore"] = new SelectList(_context.Autori, "Id", "Cognome");
            ViewData["IdEditore"] = new SelectList(_context.Editori, "Id", "Denominazione");
            return View();
        }

        // POST: Libri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAutore"] = new SelectList(_context.Autori, "Id", "Cognome", libro.ID_Autore);
            ViewData["IdEditore"] = new SelectList(_context.Editori, "Id", "Denominazione", libro.ID_Editore);
            return View(libro);
        }

        // GET: Libri/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libri == null)
            {
                return NotFound();
            }

            var libro = await _context.Libri.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["ID_Autore"] = new SelectList(_context.Autori, "Id", "Cognome", libro.ID_Autore);
            ViewData["ID_Editore"] = new SelectList(_context.Editori, "Id", "Denominazione", libro.ID_Editore);
            return View(libro);
        }

        // POST: Libri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titolo,ID_Autore,ID_Editore")] Libro libro)
        {
            if (id != libro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
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
            ViewData["ID_Autore"] = new SelectList(_context.Autori, "Id", "Cognome", libro.ID_Autore);
            ViewData["ID_Editore"] = new SelectList(_context.Editori, "Id", "Denominazione", libro.ID_Editore);
            return View(libro);
        }

        // GET: Libri/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libri == null)
            {
                return NotFound();
            }

            var libro = await _context.Libri
                .Include(l => l.Autore)
                .Include(l => l.Editore)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libri/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libri == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Libri'  is null.");
            }
            var libro = await _context.Libri.FindAsync(id);
            if (libro != null)
            {
                _context.Libri.Remove(libro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
          return (_context.Libri?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
