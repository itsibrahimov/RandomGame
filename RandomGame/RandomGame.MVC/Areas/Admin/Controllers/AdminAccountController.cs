using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RandomGame.DataAccess.Context;
using RandomGame.Entity.POCO;
using System.Linq;

namespace RandomGame.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/{controller=AdminAccount}/{action=AdminLogin}/{id?}")]
    public class AdminAccountController : Controller
    {
        RandomGameDbContext context;
        SignInManager<AppUser> signInManager;
        UserManager<AppUser> userManager;
        public AdminAccountController(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager,RandomGameDbContext randomGameDb)
        {
            context = randomGameDb;
            this.signInManager = signInManager;
            this.userManager= userManager;
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminLogin(string userName,string password)
        {
            var result = signInManager.PasswordSignInAsync(userName, password, false, false);


            if (result.Result.Succeeded)
            {
                return Redirect("https://localhost:44353/admin/Dashboard/Index");
            }
            return View();
        }

        public IActionResult Exit()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("AdminLogin");
        }
    }
}
