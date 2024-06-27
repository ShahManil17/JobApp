using JobApplicationForm.Areas.Identity.Pages.Account;
using JobApplicationForm.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobApplicationForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogger<JobApplicationForm.Areas.Identity.Pages.Account.LoginModel> _Ilogger;
        public readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> signInManager, ILogger<JobApplicationForm.Areas.Identity.Pages.Account.LoginModel> Ilogger)
        {
            _logger = logger;
            _Ilogger = Ilogger;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("/Areas/Identity/Pages/Account/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> LoginPost(Input input)
        {
            LoginModel obj = new LoginModel(_signInManager, _Ilogger);
            await obj.OnPostAsync(input.Email, input.Password, input.RememberMe, "");
            return RedirectToAction("List", "Services");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
