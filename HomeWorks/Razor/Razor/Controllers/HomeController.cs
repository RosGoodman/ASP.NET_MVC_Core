using Common.Entityes;
using Microsoft.AspNetCore.Mvc;
using Razor.Models;
using System.Diagnostics;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private List<Contact> _contacts;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            var contactData = new ContactData();
            _contacts = contactData.Contacts;
        }

        public IActionResult Index()
        {
            ContactsViewModel ivm = new ContactsViewModel { Contacts = _contacts };

            return View(ivm);
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
    }
}