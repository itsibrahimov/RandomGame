using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RandomGame.Entity.POCO;

namespace RandomGame.MVC.Controllers
{
    public class AccountController : Controller
    {
        UserManager<AppUser> userManager;
        SignInManager<AppUser> signIn;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signIn)
        {
            this.userManager = userManager;
            this.signIn = signIn;
            
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Signup(string userName,string email, string password)
        {
            AppUser user = new AppUser() { UserName=userName,Email=email,NormalizedEmail=email.ToUpper(),NormalizedUserName=userName.ToUpper()};

           var ıdentityResult=userManager.CreateAsync(user, password);
            if (ıdentityResult.Result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var item in ıdentityResult.Result.Errors)
                {
                    ModelState.AddModelError("Kayıt Hataları", item.Description);
                }
                return RedirectToAction("Register");
            }

        }
        public IActionResult Signin(string userName, string password)
        {
            var result = signIn.PasswordSignInAsync(userName, password, false, false);
            if (result.Result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Login");
        }
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Logout()
        {
            signIn.SignOutAsync();
           return RedirectToAction("Index", "Home");
        }

    }
}
