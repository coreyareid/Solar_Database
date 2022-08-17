using Dapper;
using System.Data;
using Project.Models;
using System.Collections.Generic;

namespace Project
{
    public class PlanetRepo : IPlanetRepo
    {
        private readonly IDbConnection _conn;
        public PlanetRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Solar> GetAllPlanets()
        {
            return _conn.Query<Solar>("SELECT * FROM Solarsystem.bodies");
        }

        public Solar GetPlanet(int id)
        {
            return _conn.QuerySingle<Solar>("SELECT * FROM Solarsystem.bodies WHERE BodyID =@id",
                new { id = id });
        }

        public void UpdateInfo(Solar body)
        {
            _conn.Execute("UPDATE Solarsystem.bodies SET EnglishName = @name, TypeOf = @type, DistanceFrom = @distance, Gravity =@gravity, AverageTemp =@averageTemp, Moons =@moons, DiscoveredBy =@discoveredBy WHERE BodyID = @id",
             new
             {
                 name = body.EnglishName,
                 type = body.TypeOf,
                 distance = body.DistanceFrom,
                 gravity = body.Gravity,
                 averageTemp = body.AverageTemp,
                 moons = body.Moons,
                 discoveredBy = body.DiscoveredBy,
                 id = body.BodyID
             });
        }

        public void AddSolarBody(Solar toBeAdded)
        {
            _conn.Execute("INSERT INTO Solarsystem.bodies (EnglishName, TypeOf, DistanceFrom, Gravity, AverageTemp, Moons, DiscoveredBy) VALUES (@name, @TypeOf, @DistanceFrom, @Gravity, @AverageTemp, @Moons, @DiscoveredBy);",
             new
             {
                 name = toBeAdded.EnglishName,
                 TypeOf = toBeAdded.TypeOf,
                 DistanceFrom = toBeAdded.DistanceFrom,
                 Gravity = toBeAdded.Gravity,
                 AverageTemp = toBeAdded.AverageTemp,
                 Moons = toBeAdded.Moons,
                 DiscoveredBy = toBeAdded.DiscoveredBy
             });
        }

        public void RemoveBody(Solar body)
        {
            _conn.Execute("DELETE FROM Solarsystem.bodies WHERE BodyID = @id;",
                new
                {
                    id = body.BodyID
                });
        }

        public IEnumerable<Solar> SearchedSolar(string searchSolar)
        {
            return _conn.Query<Solar>($"SELECT * FROM Solarsystem.bodies WHERE EnglishName LIKE '%{searchSolar}%';");
        }
    }
}

