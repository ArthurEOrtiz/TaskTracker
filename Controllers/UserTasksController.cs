using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskTracker.DataAccess;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class UserTasksController : Controller
    {
        private readonly TaskTrackerDbContext _context;

        public UserTasksController(TaskTrackerDbContext context)
        {
            _context = context;
        }

        // GET: UserTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserTasks.ToListAsync());
        }

        // GET: UserTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTask = await _context.UserTasks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (userTask == null)
            {
                return NotFound();
            }

            return View(userTask);
        }

        // GET: UserTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate,IsCompleted,UpdatedAt")] UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTask);
        }

        // GET: UserTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTask = await _context.UserTasks.FindAsync(id);
            if (userTask == null)
            {
                return NotFound();
            }
            return View(userTask);
        }

        // POST: UserTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate,IsCompleted,UpdatedAt")] UserTask userTask)
        {
            if (id != userTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTaskExists(userTask.Id))
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
            return View(userTask);
        }

        // GET: UserTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTask = await _context.UserTasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTask == null)
            {
                return NotFound();
            }

            return View(userTask);
        }

        // POST: UserTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTask = await _context.UserTasks.FindAsync(id);
            if (userTask != null)
            {
                _context.UserTasks.Remove(userTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTaskExists(int id)
        {
            return _context.UserTasks.Any(e => e.Id == id);
        }
    }
}
