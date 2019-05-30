using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject322.Models;
using FinalProject322.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

/*CartController ve HomeAdmin içindeki sepete ekleme ile ilgili kodlar aşağıdaki linklerden araştırılarak 
 * ve bazı kodlar kullanılarak yapılmıştır. Ayrıca claimsIdentity kullanımı da netten bulunmuştur. Bilgilerinize.
https://docs.microsoft.com/tr-tr/aspnet/web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/shopping-carthttps://www.youtube.com/watch?v=A-5VqQqmjd4
https://www.youtube.com/watch?v=A-5VqQqmjd4
http://www.alptekinbodur.com/makale/Asp.Net-C-Sharp-Session-Sepet-Yapmak/
https://www.youtube.com/watch?v=h_jfcLICk_8
*/
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
            ViewModals vm = new ViewModals()
            {
                Product = await _context.Product.Include(m => m.Category).ToListAsync(),
                Category = await _context.Category.ToListAsync(),
                Kupon = await _context.Kupon.Where(m => m.IsActive == true).ToListAsync()
            };

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                var cnt = _context.ShoppingCart.Where(u => u.UserrId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32("ssCartCount", cnt);
            }





            return View(await _context.Product.ToListAsync());
        }
       
        public async Task<IActionResult> Details(int id)
        {
            var productdb = await _context.Product.Include(m => m.Category).Where(m => m.Id == id).FirstOrDefaultAsync();

            ShoppingCart cartObj = new ShoppingCart()
            {
                Product = productdb,
               ProductId=productdb.Id

            };


            return View(cartObj);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(ShoppingCart CardObject)
        {
            CardObject.Id = 0;

            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                CardObject.UserrId = claim.Value;
               



                ShoppingCart cartdb = await _context.ShoppingCart.Where(c => c.UserrId == CardObject.UserrId && c.ProductId==CardObject.ProductId).FirstOrDefaultAsync();



                if (cartdb == null)
                {
                    await _context.ShoppingCart.AddAsync(CardObject);
                }
                else
                {
                    cartdb.Quantity = cartdb.Quantity + CardObject.Quantity;
                }
                await _context.SaveChangesAsync();

                var count = _context.ShoppingCart.Where(c => c.UserrId == CardObject.UserrId).ToList().Count();
                HttpContext.Session.SetInt32("ssCartCount", count);

                return RedirectToAction("Index");
            }

            else
            {
                var productdb = await _context.Product.Include(m => m.Category).Where(m => m.Id == CardObject.ProductId).FirstOrDefaultAsync();

                ShoppingCart cartObj = new ShoppingCart()
                {
                    Product = productdb,
                    ProductId = productdb.Id
                };

                return View(cartObj);

            }

        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
