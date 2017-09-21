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
    public class ApiariesController : Controller
    {
        private readonly MonitorContext _context;

        public ApiariesController(MonitorContext context)
        {
            _context = context;
        }

        // GET: Apiaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apiaries.ToListAsync());
        }

        // GET: Apiaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiary = await _context.Apiaries
                .SingleOrDefaultAsync(m => m.ID == id);
            if (apiary == null)
            {
                return NotFound();
            }

            return View(apiary);
        }

        // GET: Apiaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apiaries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Postcode")] Apiary apiary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apiary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apiary);
        }

        // GET: Apiaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiary = await _context.Apiaries.SingleOrDefaultAsync(m => m.ID == id);
            if (apiary == null)
            {
                return NotFound();
            }
            return View(apiary);
        }

        // POST: Apiaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Postcode")] Apiary apiary)
        {
            if (id != apiary.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apiary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApiaryExists(apiary.ID))
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
            return View(apiary);
        }

        // GET: Apiaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiary = await _context.Apiaries
                .SingleOrDefaultAsync(m => m.ID == id);
            if (apiary == null)
            {
                return NotFound();
            }

            return View(apiary);
        }

        // POST: Apiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apiary = await _context.Apiaries.SingleOrDefaultAsync(m => m.ID == id);
            _context.Apiaries.Remove(apiary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApiaryExists(int id)
        {
            return _context.Apiaries.Any(e => e.ID == id);
        }
    }
}
