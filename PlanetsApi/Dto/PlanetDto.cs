using PlanetsApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlanetsApi.Dto
{
    public class PlanetDto
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Climate { get; private set; }
        public string Terrain { get; private set; }
        public int Apparitions { get; private set; }

        public PlanetDto(Planet planet)
        {
            Id = planet.Id;
            Name = planet.Name;
            Climate = planet.Climate;
            Terrain = planet.Terrain;
            Apparitions = planet.ApparitionsInFilms;
        }

        public static List<PlanetDto> Convert(List<Planet> planets) => planets.Select(planet => new PlanetDto(planet)).ToList();
    }
}
