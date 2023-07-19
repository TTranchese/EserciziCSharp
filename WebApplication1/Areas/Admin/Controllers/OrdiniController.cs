using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrdiniController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdiniController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Ordini
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ordini.Include(o => o.IdentityUser).Include(o => o.Prodotto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Ordini/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ordini == null)
            {
                return NotFound();
            }

            var ordine = await _context.Ordini
                .Include(o => o.IdentityUser)
                .Include(o => o.Prodotto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordine == null)
            {
                return NotFound();
            }

            return View(ordine);
        }

        // GET: Admin/Ordini/Create
        public IActionResult Create()
        {
            ViewData["IdUtente"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["IdProdotto"] = new SelectList(_context.Prodotti, "Id", "Nome");
            return View();
        }

        // POST: Admin/Ordini/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProdotto,IdUtente")] Ordine ordine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUtente"] = new SelectList(_context.Users, "Id", "Id", ordine.IdUtente);
            ViewData["IdProdotto"] = new SelectList(_context.Prodotti, "Id", "Nome", ordine.IdProdotto);
            return View(ordine);
        }

        // GET: Admin/Ordini/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ordini == null)
            {
                return NotFound();
            }

            var ordine = await _context.Ordini.FindAsync(id);
            if (ordine == null)
            {
                return NotFound();
            }
            ViewData["IdUtente"] = new SelectList(_context.Users, "Id", "Id", ordine.IdUtente);
            ViewData["IdProdotto"] = new SelectList(_context.Prodotti, "Id", "Nome", ordine.IdProdotto);
            return View(ordine);
        }

        // POST: Admin/Ordini/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProdotto,IdUtente")] Ordine ordine)
        {
            if (id != ordine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdineExists(ordine.Id))
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
            ViewData["IdUtente"] = new SelectList(_context.Users, "Id", "Id", ordine.IdUtente);
            ViewData["IdProdotto"] = new SelectList(_context.Prodotti, "Id", "Nome", ordine.IdProdotto);
            return View(ordine);
        }

        // GET: Admin/Ordini/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ordini == null)
            {
                return NotFound();
            }

            var ordine = await _context.Ordini
                .Include(o => o.IdentityUser)
                .Include(o => o.Prodotto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordine == null)
            {
                return NotFound();
            }

            return View(ordine);
        }

        // POST: Admin/Ordini/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ordini == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ordini'  is null.");
            }
            var ordine = await _context.Ordini.FindAsync(id);
            if (ordine != null)
            {
                _context.Ordini.Remove(ordine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdineExists(int id)
        {
          return (_context.Ordini?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
