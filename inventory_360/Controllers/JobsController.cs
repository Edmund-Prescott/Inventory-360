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
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            return View(await _context.job.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.job
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            CreateJobView jobView = new CreateJobView();
            jobView.StartDate = DateTime.Now;
            jobView.FinishDate = DateTime.Now;
            List<Equipment> equipList = _context.equipment.ToList<Equipment>();
            List<Employee> empList = _context.employee.ToList<Employee>();
            List<Client> clientList = _context.client.ToList<Client>();
            jobView.Equipments = equipList;
            jobView.Employees = empList;
            jobView.Clients = clientList;
            return View(jobView);
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,FinishDate,SelectedEquipmentId,SelectedEmployeeId,SelectedClientId")] CreateJobView job)
        {
            Job tempJob = new Job();
            if (ModelState.IsValid)
            {
                tempJob.StartDate = job.StartDate;
                tempJob.FinishDate = job.FinishDate;
                tempJob.Equpiment = _context.equipment.Find(job.SelectedEquipmentId);
                tempJob.Employee = _context.employee.Find(job.SelectedEmployeeId);
                tempJob.Client = _context.client.Find(job.SelectedClientId);
                _context.Add(tempJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EditJobView viewModel = new EditJobView();
            var job = await _context.job.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            List<Equipment> equipList = _context.equipment.ToList<Equipment>();
            List<Employee> empList = _context.employee.ToList<Employee>();
            List<Client> clientList = _context.client.ToList<Client>();

            viewModel.StartDate = job.StartDate;
            viewModel.FinishDate = job.FinishDate;
            viewModel.Equipments = equipList;
            viewModel.Employees = empList;
            viewModel.Clients = clientList;
            return View(viewModel);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StartDate,FinishDate,SelectedEquipmentId,SelectedEmployeeId,SelectedClientId")] EditJobView editedJobInfo)
        {
            if (id != editedJobInfo.Id)
            {
                return NotFound();
            }
            Job? jobEvent;
            if (ModelState.IsValid)
            {
                try
                {
                    jobEvent = await _context.job.FirstOrDefaultAsync(f => f.Id == id);
                    if (jobEvent == null)
                    {
                        return NotFound();
                    }
                    jobEvent.StartDate = editedJobInfo.StartDate;
                    jobEvent.FinishDate = editedJobInfo.FinishDate;
                    jobEvent.Equpiment = _context.equipment.Find(editedJobInfo.SelectedEquipmentId);
                    jobEvent.Employee = _context.employee.Find(editedJobInfo.SelectedEmployeeId);
                    jobEvent.Client = _context.client.Find(editedJobInfo.SelectedClientId);
                    _context.Update(jobEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(id))
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
            return View(editedJobInfo);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.job
                .FirstOrDefaultAsync(m => m.Id == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.job.FindAsync(id);
            _context.job.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(int id)
        {
            return _context.job.Any(e => e.Id == id);
        }
    }
}
