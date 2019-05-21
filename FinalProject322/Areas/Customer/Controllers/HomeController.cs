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
    [Area("Customer")]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task<IActionResult> Index()

        {
            ViewModals vm = new ViewModals()
            {
                Product = await _context.Product.Include(m => m.Category).ToListAsync(),
                Category = await _context.Category.ToListAsync(),
                Kupon=await _context.Kupon.Where(c=>c.IsActive==true).ToListAsync(),
            };


            return View(vm);
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
