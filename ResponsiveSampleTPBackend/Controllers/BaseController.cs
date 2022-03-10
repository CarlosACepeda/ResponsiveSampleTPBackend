using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResponsiveSampleTPBackend.Database;
using ResponsiveSampleTPBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResponsiveSampleTPBackend.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ILogger _logger;
        protected readonly DatabaseContext _context;
        public BaseController(ILogger logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }
        bool IsUserLoggedIn()
        {
            byte[] sessionValue;
            bool found = HttpContext.Session.TryGetValue("ISLOGGEDIN", out sessionValue);
            return found && sessionValue[0] == 1;
        }
        protected void SaveLoginInfo(User loggedInUser, bool isLogged)
        {
            HttpContext.Session.Set("ISLOGGEDIN", new byte[1] { (byte)(isLogged ? 1 : 0) });
            if (isLogged)
                HttpContext.Session.Set("userid", new byte[1] { (byte)(loggedInUser.ID) });
            else
                HttpContext.Session.Remove("userid");

        }
        protected User GetLoggedInUser()
        {
            if (IsUserLoggedIn())
            {
                byte[] userId;
                HttpContext.Session.TryGetValue("userid", out userId);
                return _context.Users.AsNoTracking().FirstOrDefault(u => u.ID == userId[0]);
            }
            return null;
        }
    }
}
