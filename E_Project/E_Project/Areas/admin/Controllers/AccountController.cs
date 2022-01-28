using E_Project.Data;
using E_Project.Models;
using E_Project.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Project.Areas.admin.Controllers
{
    [Area("admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;

        public AccountController(AppDbContext context, UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(VmRegister model)
        {
            if (ModelState.IsValid)
            {
                CustomUser user = new CustomUser()
                {
                    Name=model.Name,
                    Surname=model.Surname,
                    Email=model.Email,
                    PasswordHash=model.Password,
                    PhoneNumber=model.Phone,
                    UserName=model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user,false);
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error S");
                    return View(model);
                }
            }

            else
            {
                ModelState.AddModelError("", "Error isvalid");
                return View(model);
            }

            return View(model);

        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(VmRegister model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Shifre ve ya Email sehvdir.");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Error");
                return View(model);
            }
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }
    }
}
