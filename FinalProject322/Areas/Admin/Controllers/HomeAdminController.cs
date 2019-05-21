using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject322.Models;
using FinalProject322.Data;
using Microsoft.EntityFrameworkCore;

namespace FinalProject322.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeAdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Product.Include(m => m.Category).Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
