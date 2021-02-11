using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatonsBDD.Models;

namespace ChatonsBDD.Controllers
{
    public class ChatonsController : Controller
    {
        private readonly ContexteBDD _context = new ContexteBDD();

        //public ChatonsController(ContexteBDD context)
        //{
        //    _context = context;
        //}

        // GET: Chatons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chaton.Include(c=>c.Categorie).ToListAsync());
        }

        // GET: Chatons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chaton = await _context.Chaton
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chaton == null)
            {
                return NotFound();
            }

            return View(chaton);
        }

        // GET: Chatons/Create
        public IActionResult Create()
        {
            ViewData["listeDesCategories"] = new SelectList(_context.Categories, "Id", "Libelle");
            return View();
        }

        // POST: Chatons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,AnneeDeNaissance")] Chaton chaton, int Categorie)
        {
            //Je vais chercher la catégorie
            var categorie = await _context.Categories.FindAsync(Categorie);
            //SI elle est nulle -> erreur!

            //j'affecte cette catégorie au chaton
            chaton.Categorie = categorie;

            //je force la réévaluation du modelstate
            ModelState.Clear();
            TryValidateModel(chaton);

            if (ModelState.IsValid)
            {
                _context.Add(chaton);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["listeDesCategorie"] = new SelectList(_context.Categories, "Id", "Libelle");
            return View(chaton);
        }

        // GET: Chatons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chaton = await _context.Chaton.FindAsync(id);
            if (chaton == null)
            {
                return NotFound();
            }
            return View(chaton);
        }

        // POST: Chatons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,AnneeDeNaissance")] Chaton chaton)
        {
            if (id != chaton.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chaton);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatonExists(chaton.Id))
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
            return View(chaton);
        }

        // GET: Chatons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chaton = await _context.Chaton
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chaton == null)
            {
                return NotFound();
            }

            return View(chaton);
        }

        // POST: Chatons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chaton = await _context.Chaton.FindAsync(id);
            _context.Chaton.Remove(chaton);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatonExists(int id)
        {
            return _context.Chaton.Any(e => e.Id == id);
        }
    }
}
