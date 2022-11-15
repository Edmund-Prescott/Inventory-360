using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using instrumentRentals2.Data;
using instrumentRentals2.Models;

namespace instrumentRentals2.Controllers
{
    public class RentalAgreementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalAgreementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RentalAgreement
        public async Task<IActionResult> Index()
        {
            return View(await _context.rentalAgreement.ToListAsync());
        }

        // GET: RentalAgreement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalAgreement = await _context.rentalAgreement
                .FirstOrDefaultAsync(m => m.id == id);
            if (rentalAgreement == null)
            {
                return NotFound();
            }

            return View(rentalAgreement);
        }

        // GET: RentalAgreement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentalAgreement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,rentalStart")] rentalAgreement rentalAgreement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentalAgreement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentalAgreement);
        }

        // GET: RentalAgreement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalAgreement = await _context.rentalAgreement.FindAsync(id);
            if (rentalAgreement == null)
            {
                return NotFound();
            }
            return View(rentalAgreement);
        }

        // POST: RentalAgreement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,rentalStart")] rentalAgreement rentalAgreement)
        {
            if (id != rentalAgreement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentalAgreement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!rentalAgreementExists(rentalAgreement.id))
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
            return View(rentalAgreement);
        }

        // GET: RentalAgreement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentalAgreement = await _context.rentalAgreement
                .FirstOrDefaultAsync(m => m.id == id);
            if (rentalAgreement == null)
            {
                return NotFound();
            }

            return View(rentalAgreement);
        }

        // POST: RentalAgreement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentalAgreement = await _context.rentalAgreement.FindAsync(id);
            _context.rentalAgreement.Remove(rentalAgreement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool rentalAgreementExists(int id)
        {
            return _context.rentalAgreement.Any(e => e.id == id);
        }
    }
}
