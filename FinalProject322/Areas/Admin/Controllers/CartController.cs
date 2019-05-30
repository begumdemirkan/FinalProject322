
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinalProject322.Data;
using FinalProject322.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject322.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CartController : Controller
    {

        private readonly ApplicationDbContext _context;
     

        [BindProperty]
        public OrderDetails detailCart { get; set; }

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            detailCart = new OrderDetails()
            {

                Order = new Models.Order()

            };

            detailCart.Order.total = 0;

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var cart = _context.ShoppingCart.Where(c => c.UserrId == claim.Value);

            if (cart != null)
            {
                detailCart.listCart = cart.ToList();
            }

            foreach (var list in detailCart.listCart)
            {
                list.Product = await _context.Product.FirstOrDefaultAsync(m => m.Id == list.ProductId);
                detailCart.Order.total = detailCart.Order.total + (list.Product.Price * list.Quantity);


            }

            detailCart.Order.totaloriginal = detailCart.Order.total;

            //if (HttpContext.Session.GetString(ssCouponCode) != null)
            //{
            //    detailCart.Order.CouponCode = HttpContext.Session.GetString(ssCouponCode);
            //}
            return View(detailCart);
        }

        public async Task<IActionResult> Plus(int cardId)
        {
            var cart = await _context.ShoppingCart.FirstOrDefaultAsync(c => c.Id == cardId);
           
            cart.Quantity += 1;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Minus(int cardId)
        {
          
                var cart = await _context.ShoppingCart.FirstOrDefaultAsync(c => c.Id == cardId);
            if (cart.Product.Quantity==1)
            {
         
                _context.ShoppingCart.Remove(cart);
                await _context.SaveChangesAsync();

                var cnt = _context.ShoppingCart.Where(u => u.UserrId == cart.UserrId).ToList().Count;

                HttpContext.Session.SetInt32(Const.ssShopingCardCount, cnt);

            }
            else
            {
                cart.Quantity -= 1;
                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Remove(int cardId)
        {
            var cart = await _context.ShoppingCart.FirstOrDefaultAsync(c => c.Id == cardId);
            cart.Quantity += 1;
            await _context.SaveChangesAsync();

            var cnt = _context.ShoppingCart.Where(u => u.UserrId == cart.UserrId).ToList().Count;

            HttpContext.Session.SetInt32(Const.ssShopingCardCount, cnt);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    


    //public IActionResult AddCoupon()
    //{


    //    if (detailCart.Order.CouponCode == null)
    //    {

    //        detailCart.Order.CouponCode = "";

    //    }
    //    HttpContext.Session.SetString(Const.ssCouponCount, detailCart.Order.CouponCode);

    //    return RedirectToAction(nameof(Index));
    //}

    //public static double Discount(Coupon coupondb, double totaloriginal)
    //{

    //}
}



}