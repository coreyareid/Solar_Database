using System.Collections.Generic;
using Project.Models;

namespace Project
{
    public interface IPlanetRepo
    {
        // Stubbed out methods for PlanetRepo
        public IEnumerable<Solar> GetAllPlanets();

        public Solar GetPlanet(int id);

        public void UpdateInfo(Solar body);

        public void AddSolarBody(Solar toBeAdded);

        public void RemoveBody(Solar body);

        public IEnumerable<Solar> SearchedSolar(string SearchPhrase);
    }
}
