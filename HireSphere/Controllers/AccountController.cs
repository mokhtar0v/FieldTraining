using DataAccess.Models;
using HireSphere.Models;
using HireSphere.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HireSphere.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, RoleManager<IdentityRole> _roleManager) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(viewModel.Email).Result;
                if(user is null) ModelState.AddModelError(string.Empty, "Invalid login attempt. User not found.");
                else
                {
                    var result = _userManager.CheckPasswordAsync(user, viewModel.Password).Result;
                    if (result)
                    {
                        var res = _signInManager.PasswordSignInAsync(user, viewModel.Password, false, false).Result;
                        if (res.Succeeded) return RedirectToAction("Index", "Home");

                    }
                    else ModelState.AddModelError(string.Empty, "Invalid Login");
                }
            }
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = registerViewModel.Email,
                    FullName = registerViewModel.FullName,
                    UserType = registerViewModel.AccountType // Set UserType based on AccountType
                };
                var result = _userManager.CreateAsync(user, registerViewModel.Password).Result;
                if (result.Succeeded)
                {
                    // Create role if it doesn't exist
                    if (!await _roleManager.RoleExistsAsync(registerViewModel.AccountType))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(registerViewModel.AccountType));
                    }

                    // Assign role
                    await _userManager.AddToRoleAsync(user, registerViewModel.AccountType);

                    // Sign in the user
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    // Redirect based on UserType
                    return registerViewModel.AccountType == "Customer"
                        ? RedirectToAction("Index", "Customer")
                        : RedirectToAction("Index", "Freelancer");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View(registerViewModel);
        }
    }
}
