using LLArtExhibition_2.Models;
using LLArtExhibition_2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LLArtExhibition_2
{
    public class ExampleController:Controller
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;

        public ExampleController(UserManager<IdentityUser> showUserViewModel
            , SignInManager<IdentityUser> signInManager)
        {
            _userManager = showUserViewModel;
            _signInManager = signInManager;
        }

        public IActionResult Index() 
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel showUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(showUserViewModel);
            }

            var user = await _userManager.FindByNameAsync(showUserViewModel.UserName);

            if(user != null)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(user, showUserViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(String.Empty, "用户名/密码不正确");
            return View(showUserViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel) 
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = registerViewModel.UserName,
/*                    Email = registerViewModel.Email,
                    PhoneNumber = registerViewModel.PhoneNumber,*/

                };
                try {
                    var resuse = await _userManager.CreateAsync(user, registerViewModel.Password);
                    if (resuse.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch(Exception ex) {
                    Console.WriteLine("error" + ex.Message);
                    ModelState.AddModelError(string.Empty, "添加失败");
                }       
            }
            return View(registerViewModel);
        }

        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
