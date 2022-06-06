using Microsoft.AspNetCore.Mvc;

// using MVCPlayer.Movies;

using Microsoft.EntityFrameworkCore;
using MVCPlayer.Models;

namespace MVCPlayer.Controllers
{
    public class StudioController : Controller
    {
        private readonly MVCPlayerContext _context;

        public StudioController(MVCPlayerContext context)
        {
            _context = context;
        }

        // GET: Studio
        public async Task<IActionResult> Index()
        {
              return _context.Studio != null ? View(await _context.Studio.Include(i => i.Movie).OrderBy(j => j.Name).ToListAsync()) : Problem("Entity set 'MVCPlayerContext.Studio'  is null.");
        }

        // GET: Studio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Studio == null)
            {
                return NotFound();
            }

            var studio = await _context.Studio
                .FirstOrDefaultAsync(m => m.ID == id);
            if (studio == null)
            {
                return NotFound();
            }

            return View(studio);
        }

        // GET: Studio/Create
        public IActionResult Create()
        {
            var movies = _context.Movies.OrderBy(i => i.Title).ToList();
            ViewBag.Movies = movies;
            return View();
        }

        // POST: Studio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, MovieId, Title")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studio);
        }

        // GET: Studio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Studio == null)
            {
                return NotFound();
            }

            var studio = await _context.Studio.FindAsync(id);
            if (studio == null)
            {
                return NotFound();
            }
            return View(studio);
        }

        // POST: Studio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StudioId,Name")] Studio studio)
        {
            if (id != studio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudioExists(studio.ID))
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
            return View(studio);
        }

        // GET: Studio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Studio == null)
            {
                return NotFound();
            }

            var studio = await _context.Studio
                .FirstOrDefaultAsync(m => m.ID == id);
            if (studio == null)
            {
                return NotFound();
            }

            return View(studio);
        }

        // POST: Studio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Studio == null)
            {
                return Problem("Entity set 'MVCPlayerContext.Studio'  is null.");
            }
            var studio = await _context.Studio.FindAsync(id);
            if (studio != null)
            {
                _context.Studio.Remove(studio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudioExists(int id)
        {
          return (_context.Studio?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
