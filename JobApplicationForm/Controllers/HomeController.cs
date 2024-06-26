using JobApplicationForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Diagnostics;
using JobApplicationForm.Data.Models;
using JobApplicationForm.Data;

namespace JobApplicationForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext app)
        {
            _logger = logger;
            _context = app;

        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            if(Request.Cookies["Id"] != null)
            {
                return View("Privacy");
            }
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(Credentials credential)
        {
            if(ModelState.IsValid)
            {
                var password = _context.Credentials
                    .Where(x => x.Username == credential.Username)
                    .Select(x => new {x.Password , x.Id})
                    .ToList();

                Console.WriteLine("Password Is : {0}", password[0]);
                if(credential.Password == password[0].Password)
                {
                    Response.Cookies.Append("Id", Convert.ToString(password[0].Id));
                }
                return View("Privacy");
            }
            else
            {
                return View();
            }
        }
    }
}
