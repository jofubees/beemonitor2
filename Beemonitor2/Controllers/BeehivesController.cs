using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beemonitor2.Data;
using Beemonitor2.Models;

namespace Beemonitor2.Controllers
{
    public class BeehivesController : Controller
    {
        private readonly MonitorContext _context;

        public BeehivesController(MonitorContext context)
        {
            _context = context;
        }

        // GET: Beehives
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //            var beehives = await _context.Beehives
            //                .ToListAsync(b => b.ApiaryID == id);
            var thisApiary = await _context.Apiaries.SingleOrDefaultAsync(m => m.ID == id);

            var beehivesForApiary = await _context.Apiaries.Include(i=> i.Beehives).SingleAsync(m => m.ID == id);
            return View(beehivesForApiary);
        }

        // GET: Beehives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beehive = await _context.Beehives
                .SingleOrDefaultAsync(m => m.ID == id);
            if (beehive == null)
            {
                return NotFound();
            }

            return View(beehive);
        }

        // GET: Beehives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beehives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Beehive beehive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beehive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beehive);
        }

        // GET: Beehives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beehive = await _context.Beehives.SingleOrDefaultAsync(m => m.ID == id);
            if (beehive == null)
            {
                return NotFound();
            }
            return View(beehive);
        }

        // POST: Beehives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Beehive beehive)
        {
            if (id != beehive.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beehive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeehiveExists(beehive.ID))
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
            return View(beehive);
        }

        // GET: Beehives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beehive = await _context.Beehives
                .SingleOrDefaultAsync(m => m.ID == id);
            if (beehive == null)
            {
                return NotFound();
            }

            return View(beehive);
        }

        // POST: Beehives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beehive = await _context.Beehives.SingleOrDefaultAsync(m => m.ID == id);
            _context.Beehives.Remove(beehive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeehiveExists(int id)
        {
            return _context.Beehives.Any(e => e.ID == id);
        }
    }
}
