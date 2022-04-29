#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MIS421FinalProject.Data;
using MIS421FinalProject.Models;

namespace MIS421FinalProject.Views
{
    public class MyExercisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyExercises
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MyExercise.Where(m => m.Username == User.Identity.Name).Include(m => m.Exercise);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MyExercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myExercise = await _context.MyExercise
                .Include(m => m.Exercise)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myExercise == null)
            {
                return NotFound();
            }

            return View(myExercise);
        }

        // GET: MyExercises/Create
        public IActionResult Create()
        {
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Id");
            ViewBag.ExerciseName = new SelectList(_context.Exercise, "Id", "Name");
            return View();
        }

        // POST: MyExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Time,ExerciseId,Username")] MyExercise myExercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myExercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Id", myExercise.ExerciseId);
            return View(myExercise);
        }

        // GET: MyExercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myExercise = await _context.MyExercise.FindAsync(id);
            if (myExercise == null)
            {
                return NotFound();
            }
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Id", myExercise.ExerciseId);
            return View(myExercise);
        }

        // POST: MyExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time,ExerciseId,Username")] MyExercise myExercise)
        {
            if (id != myExercise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myExercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyExerciseExists(myExercise.Id))
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
            ViewData["ExerciseId"] = new SelectList(_context.Exercise, "Id", "Id", myExercise.ExerciseId);
            return View(myExercise);
        }

        // GET: MyExercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myExercise = await _context.MyExercise
                .Include(m => m.Exercise)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myExercise == null)
            {
                return NotFound();
            }

            return View(myExercise);
        }

        // POST: MyExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myExercise = await _context.MyExercise.FindAsync(id);
            _context.MyExercise.Remove(myExercise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyExerciseExists(int id)
        {
            return _context.MyExercise.Any(e => e.Id == id);
        }
    }
}
