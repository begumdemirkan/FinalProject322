
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinalProject322.Data;
using FinalProject322.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject322.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CartController : Controller
    {

        private readonly ApplicationDbContext _context;

        [BindProperty]
        public OrderDetails detailCart  { get; set; }

        public CartController (ApplicationDbContext context)
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

            if (cart!= null)
            {
                detailCart.listCart = cart.ToList();
            }

            foreach(var list in detailCart.listCart)
            {
                list.Product = await _context.Product.FirstOrDefaultAsync(m => m.Id == list.ProductId);
                detailCart.Order.total = detailCart.Order.total + (list.Product.Price * list.Quantity);
    
                    
            }

            detailCart.Order.totaloriginal =detailCart.Order.total;
            return View(detailCart);
        }

         
    }
}