﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebApplication1.ViewsModel;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Mensagem");
            }
            return View();
        }

        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> LoginPost(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Mensagem");
                }
            }
            ModelState.AddModelError("", "Faild to Login");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Mensagem");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ActionName("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterPost(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    UserName = registerModel.UserName,
                    PhoneNumber = registerModel.PhoneNumber,
                    Email = registerModel.Email
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    bool roleExists = await _roleManager.RoleExistsAsync(registerModel.RoleName);
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(registerModel.RoleName));
                    }

                    if (!await _userManager.IsInRoleAsync(user, registerModel.RoleName))
                    {
                        await _userManager.AddToRoleAsync(user, registerModel.RoleName);
                    }

                    if (!string.IsNullOrWhiteSpace(user.Email))
                    {
                        Claim claim = new Claim(ClaimTypes.Email, user.Email);
                        await _userManager.AddClaimAsync(user, claim);
                    }

                    var resultSignIn = await _signInManager.PasswordSignInAsync(registerModel.UserName, registerModel.Password, registerModel.RememberMe, false);
                    if (resultSignIn.Succeeded)
                    {
                        return RedirectToAction("Index", "Mensagem");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}