using System.Collections.Generic;
using PlanetsApi.Dto;
using PlanetsApi.Models;

namespace PlanetsApi.Service
{
    public interface IPlanetService
    {
        Planet Create(PlanetInputDto planetInput);
        void Delete(int id);
        List<Planet> GetAll();
        Planet GetById(int id);
        Planet GetByName(string planetName);
    }
}