using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResponsiveSampleTPBackend.Database;
using ResponsiveSampleTPBackend.Models;
using ResponsiveSampleTPBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResponsiveSampleTPBackend.Controllers
{
    public class HobbyController : BaseController
    {
        public HobbyController(ILogger<HobbyController> logger, DatabaseContext context): base(logger, context)
        {

        }
        public IActionResult Index(int userId)
        {
            ViewData["UserModel"] = GetLoggedInUser();
            return View(_context.Users.Include(h=> h.Hobbies).AsNoTracking().FirstOrDefault(u => u.ID == userId));
        }
        public IActionResult SetHobby(int userId)
        {
            ViewData["UserModel"] = GetLoggedInUser();
            return View(new NewHobbyForUserViewModel
            {
                UserToAttachNewHobbyTo = _context.Users.AsNoTracking().FirstOrDefault(u => u.ID == userId),
                SelectableHobbies = _context.Hobbies.ToList()
            });
        }
        public IActionResult PickHobby(int hobbyId, int userId)
        {
            Hobby selectedHobby= _context.Hobbies.AsNoTracking().FirstOrDefault(h => h.ID == hobbyId);
            User userToAttachNewHobbyTo = _context.Users.FirstOrDefault(u => u.ID == userId);

            userToAttachNewHobbyTo.Hobbies.Add(selectedHobby);

            _context.SaveChanges();

            return RedirectToAction("Index", new { userId });
        }
        public IActionResult Delete(int hobbyId, int userId)
        {
            Hobby selectedHobby = _context.Hobbies.FirstOrDefault(h => h.ID == hobbyId);
            User userToDeleteHobbyFrom = _context.Users.Include(h=> h.Hobbies).FirstOrDefault(u => u.ID == userId);

            userToDeleteHobbyFrom.Hobbies.Remove(selectedHobby);

            _context.SaveChanges();

            return RedirectToAction("Index", new { userId });

        }
    }
}
