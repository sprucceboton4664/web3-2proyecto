using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerParcial.Models;
using PrimerParcial.Data;
using Microsoft.EntityFrameworkCore;

namespace PrimerParcial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RecetasDBContext _context;

        public HomeController(ILogger<HomeController> logger, RecetasDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Get some stats for the homepage
            ViewBag.CategoryCount = await _context.Categories.CountAsync();
            ViewBag.RecipeCount = await _context.Recipes.CountAsync();
            ViewBag.IngredientCount = await _context.Ingredients.CountAsync();

            // Get recent recipes
            ViewBag.RecentRecipes = await _context.Recipes
                .Include(r => r.Category)
                .OrderByDescending(r => r.CreatedDate)
                .Take(3)
                .ToListAsync();

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
