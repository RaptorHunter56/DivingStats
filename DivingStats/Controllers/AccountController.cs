using DivingStats.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DivingStats.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser<string>> _signInManager;

        public AccountController(SignInManager<IdentityUser<string>> signInManager)
        {
            _signInManager = signInManager;
        }

        public ActionResult Login()
        {
            ViewData["LastLoginFailed"] = false;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LogOnModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["LastLoginFailed"] = true;
                return View();
            }
        }
    }
}
