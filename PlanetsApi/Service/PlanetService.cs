using PlanetsApi.Dto;
using PlanetsApi.Models;
using PlanetsApi.Repository.Interfaces;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;

namespace PlanetsApi.Service
{
    public class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository _planetRepository;

        public PlanetService(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        public List<Planet> GetAll()
        {
            List<Planet> planets = _planetRepository.FindAll().ToList();
            planets.ForEach(p => p.ApparitionsInFilms = GetPlanetFromSwapi(p.Name));
            return planets;
        }

        public Planet Create(PlanetInputDto planetInput)
        {
            Planet newPlanet = _planetRepository.Create(new Planet(planetInput.Name, planetInput.Climate, planetInput.Terrain));
            _planetRepository.SaveChanges();

            newPlanet.ApparitionsInFilms = GetPlanetFromSwapi(newPlanet.Name);
            return newPlanet;
        }

        public void Delete(int id)
        {
            _planetRepository.Delete(id);
            _planetRepository.SaveChanges();
        }

        public Planet GetById(int id)
        {
            Planet planet = _planetRepository.FindByCondition(p => p.Id == id).FirstOrDefault();
            planet.ApparitionsInFilms = GetPlanetFromSwapi(planet.Name);
            return planet;
        }

        public Planet GetByName(string planetName)
        {
            Planet planet = _planetRepository.FindByCondition(p => p.Name == planetName).FirstOrDefault();
            planet.ApparitionsInFilms = GetPlanetFromSwapi(planet.Name);
            return planet;
        }

        private int GetPlanetFromSwapi(string planetName)
        {
            string url = "https://swapi.co/api/planets?search=" + planetName;

            var client = new RestClient(url)
            {
                CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Revalidate)
            };

            var request = new RestRequest(Method.GET);

            var response = client.Execute<PlanetResponse>(request);
            return response.Data.Results.First().Films.Count;
        }
    }
}
