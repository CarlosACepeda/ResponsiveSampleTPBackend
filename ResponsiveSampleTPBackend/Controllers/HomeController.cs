using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResponsiveSampleTPBackend.Database;
using ResponsiveSampleTPBackend.Models;
using System.Diagnostics;
using System.Linq;

namespace ResponsiveSampleTPBackend.Controllers
{
    public class HomeController : BaseController
    {
        

        public HomeController(ILogger<HomeController> logger, DatabaseContext context): base(logger, context)
        {

        }

        public IActionResult Index()
        {
            ViewData["UserModel"] = GetLoggedInUser();
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {           
            //Lets check if an user exists that matches these
            if (_context.Users.AsNoTracking().Any(u => u.Username == user.Username && u.Password == user.Password))
            {
                var currentUser = _context.Users.AsNoTracking().FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                SaveLoginInfo(currentUser, true);
                ViewData["UserModel"] = GetLoggedInUser();
                return View(GetLoggedInUser());
            }
            else
            {
                SaveLoginInfo(null, false);
                return View(user);
            }

        }

        public IActionResult UserDetails()
        {
            ViewData["UserModel"] = GetLoggedInUser();
            return View(_context.Users.Include(h => h.Hobbies).AsNoTracking().ToList());
        }
        public IActionResult Create()
        {
            ViewData["UserModel"] = GetLoggedInUser();

            return View();
        }

        [HttpPost]
        public IActionResult Create(User newUser)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return RedirectToAction("UserDetails");
            }
            ViewData["UserModel"] = GetLoggedInUser();
            return View(newUser);

        }

        public IActionResult Update(int userId)
        {
            ViewData["UserModel"] = GetLoggedInUser();
            return View(_context.Users.FirstOrDefault(u => u.ID == userId));
        }

        [HttpPost]
        public IActionResult Update(User userToBeUpdated)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.ID == userToBeUpdated.ID);

                user.Name = userToBeUpdated.Name;
                user.Username = userToBeUpdated.Username;
                user.Phonenumber = userToBeUpdated.Phonenumber;
                //can't update your password

                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("UserDetails");
            }
            ViewData["UserModel"] = GetLoggedInUser();
            return View(userToBeUpdated);

        }

        public IActionResult Delete(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.ID == userId);
            if (userId != GetLoggedInUser()?.ID)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                //We can't delete ourselves!
            }

            return RedirectToAction("UserDetails");

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

        public IActionResult GetSideMenu()
        {
            ViewData["UserModel"] = GetLoggedInUser();
            return new PartialViewResult
            {
                ViewName = "_sideMenu",
                ViewData = ViewData,
            };
        }
    }
}
