using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project;
using Project.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Controllers
{
    public class SolarController : Controller
    {

        private readonly IPlanetRepo repo;
        public SolarController(IPlanetRepo repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/
        public IActionResult SolarIndex()
        {
            var planets = repo.GetAllPlanets();
            return View(planets);
        }

        public IActionResult ViewPlanet(int id)
        {
            var planet = repo.GetPlanet(id);
            return View(planet);
        }


        // updeate Section controller
        public IActionResult UpdateInfo(int id)
        {
            Solar bod = repo.GetPlanet(id);

            if (bod == null)
            {
                return View("Body Not Found");
            }
            return View(bod);
        }

        public IActionResult UpdateInfoToDataBase(Solar body)
        {
            repo.UpdateInfo(body);
            return RedirectToAction("ViewPlanet", new { id = body.BodyID });
        }

        // Create section of controller

        public IActionResult InsertBody()
        {

            return View();
        }

        public IActionResult InsertBodyIntoDatabase(Solar toBeAdded)
        {
            repo.AddSolarBody(toBeAdded);
            return RedirectToAction("SolarIndex");
        }

        public IActionResult RemoveBody(Solar body)
        {
            repo.RemoveBody(body);
            return RedirectToAction("SolarIndex");
        }

        public IActionResult ShowSearchResults(string SearchPhrase)
        {
            var filteredSolars = repo.SearchedSolar(SearchPhrase);
            return View(filteredSolars);
        }
    }
}

