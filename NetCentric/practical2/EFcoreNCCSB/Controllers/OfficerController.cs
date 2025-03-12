using Microsoft.AspNetCore.Mvc;
using EFCoreNCCSB.Models;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EFCoreNCCSB.Controllers
{
    public class OfficerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfficerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LIST ALL OFFICERS
        public async Task<IActionResult> Index()
        {
            var officers = await _context.Officers.ToListAsync();  // ✅ Ensure this returns a list
            return View(officers); // Pass the list to the view
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Officer officer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(officer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(officer);
        }

        // EDIT (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var officer = await _context.Officers.FindAsync(id);
            if (officer == null) return NotFound();
            return View(officer);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Officer officer)
        {
            if (id != officer.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(officer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(officer);
        }

        // DELETE (GET)
        public async Task<IActionResult> Delete(int id)
        {
            var officer = await _context.Officers.FindAsync(id);
            if (officer == null) return NotFound();
            return View(officer);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officer = await _context.Officers.FindAsync(id);
            if (officer != null)
            {
                _context.Officers.Remove(officer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}