using LoginApplication2Jours.Areas.Identity.Data;
using LoginApplication2Jours.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LoginApplication2Jours.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly App2JoursDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, App2JoursDbContext context)
        {
            _logger = logger;
            this._userManager = userManager;
            _context = context;
        }

        public  IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
           
            var user = (from u in _context.Users
                       where u.Id == userId
                       select u).FirstOrDefault<User>();

            if (user != null)
            {
                ViewData["FullName"] = $"{user.FirstName} {user.LastName}";
            }

            var users = _userManager.Users.ToList();


            return View(users);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}