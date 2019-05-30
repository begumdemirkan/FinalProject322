using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject322.Data;
using FinalProject322.Models;
using FinalProject322.Models;
using FinalProject322.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject322.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class UserManagementController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Userr> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(ApplicationDbContext context, UserManager<Userr> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        // GET: UserManagement
        public async Task<ActionResult> Index()
        {

            var userList = _context
                .Users
                .ToList();
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", -1);
            List<UserViewmodel> userModelList = new List<UserViewmodel>();

            foreach (var item in userList)
            {
                bool isadmin = await _userManager.IsInRoleAsync(item, "admin");
                var user = new UserViewmodel
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    FullName = item.Ad+ " " + item.Soyad,
                    IsAdmin = isadmin
                };
                userModelList.Add(user);
            }
            return View(userModelList);
        }

        // GET: UserManagement/Details/5
        public async Task<ActionResult> MakeAdmin(string id)
        {
            if (!(await _roleManager.RoleExistsAsync("admin")))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
            }
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, "admin");
            return RedirectToAction("index");
        }
        [HttpPost]
        public async Task<ActionResult> MakeCategoryAdmin(string UserId, int CategoryId)
        {
            if (!(await _roleManager.RoleExistsAsync("CategoryAdmin")))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "CategoryAdmin" });
            }
            var user = await _userManager.FindByIdAsync(UserId);
            user.CategoryId = CategoryId;
            await _context.SaveChangesAsync();
            await _userManager.AddToRoleAsync(user, "CategoryAdmin");
            return RedirectToAction("index");
        }
        public async Task<ActionResult> RemoveAdmin(string id)
        {

            var user = await _userManager.FindByIdAsync(id);
            await _userManager.RemoveFromRoleAsync(user, "admin");
            return RedirectToAction("index");
        }


    }
}