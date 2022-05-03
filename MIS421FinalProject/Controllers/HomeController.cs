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
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace MIS421FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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

        public async Task<IActionResult> Create(string username, string password)
        {
            if (ModelState.IsValid)
            {
                _userManager.CreateAsync(new IdentityUser
                {
                    UserName = username,
                    Email = username,
                    EmailConfirmed = true
                }, password).GetAwaiter().GetResult();

                IdentityUser user = _context.Users.Where(u => u.Email == username).FirstOrDefault();
                _userManager.AddToRoleAsync(user, SD.Admin).GetAwaiter().GetResult();
            }
            return View();
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
