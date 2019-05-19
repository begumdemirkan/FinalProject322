using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject322.Data;
using FinalProject322.Models;

namespace FinalProject322.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KuponsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KuponsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Kupons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kupon.ToListAsync());
        }

        // GET: Admin/Kupons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kupon = await _context.Kupon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kupon == null)
            {
                return NotFound();
            }

            return View(kupon);
        }

        // GET: Admin/Kupons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Kupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Indirim,Minmiktar,IsActive")] Kupon kupon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kupon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kupon);
        }

        // GET: Admin/Kupons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kupon = await _context.Kupon.FindAsync(id);
            if (kupon == null)
            {
                return NotFound();
            }
            return View(kupon);
        }

        // POST: Admin/Kupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Indirim,Minmiktar,IsActive")] Kupon kupon)
        {
            if (id != kupon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kupon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KuponExists(kupon.Id))
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
            return View(kupon);
        }

        // GET: Admin/Kupons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kupon = await _context.Kupon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kupon == null)
            {
                return NotFound();
            }

            return View(kupon);
        }

        // POST: Admin/Kupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kupon = await _context.Kupon.FindAsync(id);
            _context.Kupon.Remove(kupon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KuponExists(int id)
        {
            return _context.Kupon.Any(e => e.Id == id);
        }
    }
}
