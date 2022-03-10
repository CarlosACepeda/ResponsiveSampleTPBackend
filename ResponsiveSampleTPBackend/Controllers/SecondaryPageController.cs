using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResponsiveSampleTPBackend.Database;
using ResponsiveSampleTPBackend.ViewModels;

namespace ResponsiveSampleTPBackend.Controllers
{
    public class SecondaryPageController : BaseController
    {
        public SecondaryPageController(ILogger<SecondaryPageController> logger, DatabaseContext context) : base(logger, context)
        {

        }
        public IActionResult Index(string page)
        {
            ViewData["UserModel"] = GetLoggedInUser();
            return View(new SecondaryPageViewModel { 
                PágeName= page
            });
        }
    }
}
