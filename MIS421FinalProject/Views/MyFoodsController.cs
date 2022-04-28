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
    public class MyFoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyFoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyFoods
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MyFood.Include(m => m.Food);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MyFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myFood = await _context.MyFood
                .Include(m => m.Food)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myFood == null)
            {
                return NotFound();
            }

            return View(myFood);
        }
        [Authorize]
        // GET: MyFoods/Create
        public IActionResult Create()
        {
            ViewData["FoodId"] = new SelectList(_context.Food, "Id", "Id");
            ViewBag.FoodName = new SelectList(_context.Food, "Id", "Name");
            return View();
        }

        // POST: MyFoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Time,FoodId,Username")] MyFood myFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodId"] = new SelectList(_context.Food, "Id", "Id", myFood.FoodId);
            return View(myFood);
        }

        // GET: MyFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myFood = await _context.MyFood.FindAsync(id);
            if (myFood == null)
            {
                return NotFound();
            }
            ViewData["FoodId"] = new SelectList(_context.Food, "Id", "Id", myFood.FoodId);
            return View(myFood);
        }

        // POST: MyFoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Time,FoodId,Username")] MyFood myFood)
        {
            if (id != myFood.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyFoodExists(myFood.Id))
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
            ViewData["FoodId"] = new SelectList(_context.Food, "Id", "Id", myFood.FoodId);
            return View(myFood);
        }

        // GET: MyFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myFood = await _context.MyFood
                .Include(m => m.Food)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myFood == null)
            {
                return NotFound();
            }

            return View(myFood);
        }

        // POST: MyFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myFood = await _context.MyFood.FindAsync(id);
            _context.MyFood.Remove(myFood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyFoodExists(int id)
        {
            return _context.MyFood.Any(e => e.Id == id);
        }
    }
}
