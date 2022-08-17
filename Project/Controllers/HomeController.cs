using Microsoft.AspNetCore.Mvc;
using Project;
using Project.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly NASAClient _client;

        public HomeController(NASAClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _client.Get();
                return View(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Login()
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

