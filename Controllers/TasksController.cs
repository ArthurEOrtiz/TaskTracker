using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTracker.DataAccess;
using TaskTracker.Models;
using TaskTracker.ViewModels;

namespace TaskTracker.Controllers
{
  public class TasksController : Controller
  {
    private readonly TaskTrackerDbContext _context;

    public TasksController(TaskTrackerDbContext context)
    {
      _context = context;
    }

    // GET: Tasks
    public async Task<IActionResult> Index()
    {
      return View(await _context.UserTasks.ToListAsync());
    }

    // GET: Tasks/Details/5
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

    // GET: Tasks/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Tasks/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create([Bind("Id,Title,Description,DueDate,Status,UpdatedAt")] UserTask userTask)
    //{
    //  if (ModelState.IsValid)
    //  {
    //    _context.Add(userTask);
    //    await _context.SaveChangesAsync();
    //    return RedirectToAction(nameof(Index));
    //  }
    //  //var tasks = await _context.UserTasks.ToListAsync();
    //  return View("Index", userTask);
    //}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Task, Action, ButtonText, FormId")] TaskFormViewModal taskFormViewModal)
    {
      if (ModelState.IsValid)
      {
        _context.Add(taskFormViewModal.Task);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }

      return View("Index", taskFormViewModal.Task);
    }

    // GET: Tasks/Edit/5
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

    // POST: Tasks/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DueDate,Status,UpdatedAt")] UserTask userTask)
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

    // GET: Tasks/Delete/5
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

    // POST: Tasks/Delete/5
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
