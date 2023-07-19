using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class ProdottiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ProdottiController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: User/Prodotti
        public async Task<IActionResult> Index()
        {
              return _context.Prodotti != null ? 
                          View(await _context.Prodotti.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Prodotti'  is null.");
        }

        // GET: User/Prodotti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prodotti == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // GET: User/Prodotti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Prodotti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Prezzo")] Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodotto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prodotto);
        }

        // GET: User/Prodotti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prodotti == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotti.FindAsync(id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto);
        }

        // POST: User/Prodotti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Prezzo")] Prodotto prodotto)
        {
            if (id != prodotto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodotto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdottoExists(prodotto.Id))
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
            return View(prodotto);
        }

        // GET: User/Prodotti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prodotti == null)
            {
                return NotFound();
            }

            var prodotto = await _context.Prodotti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prodotto == null)
            {
                return NotFound();
            }

            return View(prodotto);
        }

        // POST: User/Prodotti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prodotti == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Prodotti'  is null.");
            }
            var prodotto = await _context.Prodotti.FindAsync(id);
            if (prodotto != null)
            {
                _context.Prodotti.Remove(prodotto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdottoExists(int id)
        {
          return (_context.Prodotti?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        //var nome = User.Identity.Name;
            
        public  async Task<IActionResult> InserisciProdotto(int id)
        {
            if (ModelState.IsValid)
            {
                Ordine ordine = new Ordine();
                ordine.IdProdotto = id;
                var name = User.Identity.Name;
                var user = await _userManager.FindByEmailAsync(name);
                ordine.IdUtente = user.Id;
                _context.Add(ordine);
                await _context.SaveChangesAsync();
                return LocalRedirect("~/User/Ordini/Index");
            }
            return LocalRedirect("~/User/Ordini/Index");
        }   
    }
}
