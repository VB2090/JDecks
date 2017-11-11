using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JDecks.Models;

namespace JDecks.Controllers
{
    public class DecksController : Controller
    {
        private readonly JDecksContext _context;

        public DecksController(JDecksContext context)
        {
            _context = context;
        }

        // GET: Decks
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Decks
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Decks
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            var movieGenreVM = new MovieGenreViewModel();
            movieGenreVM.genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            movieGenreVM.movies = await movies.ToListAsync();

            return View(movieGenreVM);
        }

        // GET: Decks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decks = await _context.Decks
                .SingleOrDefaultAsync(m => m.ID == id);
            if (decks == null)
            {
                return NotFound();
            }

            return View(decks);
        }

        // GET: Decks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Decks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price")] Decks decks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(decks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(decks);
        }

        // GET: Decks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decks = await _context.Decks.SingleOrDefaultAsync(m => m.ID == id);
            if (decks == null)
            {
                return NotFound();
            }
            return View(decks);
        }

        // POST: Decks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price")] Decks decks)
        {
            if (id != decks.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(decks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DecksExists(decks.ID))
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
            return View(decks);
        }

        // GET: Decks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decks = await _context.Decks
                .SingleOrDefaultAsync(m => m.ID == id);
            if (decks == null)
            {
                return NotFound();
            }

            return View(decks);
        }

        // POST: Decks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var decks = await _context.Decks.SingleOrDefaultAsync(m => m.ID == id);
            _context.Decks.Remove(decks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DecksExists(int id)
        {
            return _context.Decks.Any(e => e.ID == id);
        }
    }
}
