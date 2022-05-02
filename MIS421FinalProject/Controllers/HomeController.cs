using Microsoft.AspNetCore.Mvc;
using MIS421FinalProject.Data;
using MIS421FinalProject.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MIS421FinalProject.Views;

namespace MIS421FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var MyVM = new FoodExerciseVM();
            MyVM.MyFoods = _context.MyFood.Where(m => m.Username == User.Identity.Name).Include(m => m.Food).ToList();
            MyVM.MyExercise = _context.MyExercise.Where(m => m.Username == User.Identity.Name).Include(m => m.Exercise).ToList();
            return View(MyVM);
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
