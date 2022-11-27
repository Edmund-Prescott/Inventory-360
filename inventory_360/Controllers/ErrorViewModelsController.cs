using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using inventory_360.Data;
using inventory_360.Models;

namespace inventory_360.Controllers
{
    public class ErrorViewModelsController : Controller
    {
        private readonly inventory_360Context _context;

        public ErrorViewModelsController(inventory_360Context context)
        {
            _context = context;
        }

        // GET: ErrorViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ErrorViewModel.ToListAsync());
        }

        // GET: ErrorViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var errorViewModel = await _context.ErrorViewModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (errorViewModel == null)
            {
                return NotFound();
            }

            return View(errorViewModel);
        }

        // GET: ErrorViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ErrorViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,RequestId")] ErrorViewModel errorViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(errorViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(errorViewModel);
        }

        // GET: ErrorViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var errorViewModel = await _context.ErrorViewModel.FindAsync(id);
            if (errorViewModel == null)
            {
                return NotFound();
            }
            return View(errorViewModel);
        }

        // POST: ErrorViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,RequestId")] ErrorViewModel errorViewModel)
        {
            if (id != errorViewModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(errorViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErrorViewModelExists(errorViewModel.id))
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
            return View(errorViewModel);
        }

        // GET: ErrorViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var errorViewModel = await _context.ErrorViewModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (errorViewModel == null)
            {
                return NotFound();
            }

            return View(errorViewModel);
        }

        // POST: ErrorViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var errorViewModel = await _context.ErrorViewModel.FindAsync(id);
            _context.ErrorViewModel.Remove(errorViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErrorViewModelExists(int id)
        {
            return _context.ErrorViewModel.Any(e => e.id == id);
        }
    }
}
