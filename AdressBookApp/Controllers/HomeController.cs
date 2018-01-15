using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdressBookApp.Models;
using Microsoft.AspNetCore.Authorization;
using AdressBookApp.Services;
using AdressBookApp.Interface;

namespace AdressBookApp.Controllers
{
    public class HomeController : Controller
    {
        private ITimeProvider timeProvider;

        private IEmailSender emailSender;
        public HomeController(IEmailSender _emailSender, ITimeProvider _timeProvider)
        {
            timeProvider = _timeProvider;
            emailSender = _emailSender;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Time = timeProvider.Now.ToString();
            await emailSender.SendEmailAsync("genti@gmail.com", "Index was executed", "It works!");
            return View();
        }

        public IActionResult IncreaseMonth()
        {
            timeProvider.Now = timeProvider.Now.AddMonths(1);
            return View("Index");
        }

        public IActionResult DecreaseMonth()
        {
            timeProvider.Now = timeProvider.Now.AddMonths(-1);
            return View("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
