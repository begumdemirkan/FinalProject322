
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
    public class CartController : Controller
    {

        private readonly ApplicationDbContext _context;

        [BindProperty]

        public OrderDetailsCard DetailsCard  { get; set; }

        public CartController (ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            DetailsCard = new OrderDetailsCard()
            {


                Order = new Models.Order()

            };

            DetailsCard.Order.total = 0;

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var cart = _context.ShoppingCart.Where(c => c.ApplicationUserId == claim.Value);

            if (cart!= null)
            {
                DetailsCard.listCart = cart.ToList();
            }

            foreach(var list in DetailsCard.listCart)
            {
                list.Product=
                list.Product=await _context.Product.FirstOrDefaultAsync(m => m.Id == list.ProductId);
                DetailsCard.Order.total = DetailsCard.Order.total + (list.Product.Price * List.count);
                    
                    
            }
            return View();
        }

         
    }
}