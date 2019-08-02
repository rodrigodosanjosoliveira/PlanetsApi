using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PlanetsApi.Dto;
using PlanetsApi.Models;
using PlanetsApi.Service;

namespace PlanetsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetsController : ControllerBase
    {
        private readonly IPlanetService _planetService;

        public PlanetsController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpGet]
        public List<PlanetDto> GetAll()
        {
            List<Planet> planets = _planetService.GetAll();
            return PlanetDto.Convert(planets);
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<PlanetDto> Get(int id)
        {
            Planet planet = _planetService.GetById(id);
            if (planet == null)
                return NotFound();
            return Ok(planet);
        }

        [HttpPost]
        public ActionResult<PlanetDto> Post([FromBody] PlanetInputDto planetInput)
        {
            Planet newPlanet = _planetService.Create(planetInput);

            return CreatedAtAction(nameof(Get), new { id = newPlanet.Id }, new PlanetDto(newPlanet));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Planet planet = _planetService.GetById(id);
            if(planet != null)
            {
                _planetService.Delete(id);
                return NoContent();
            }

            return NotFound();
        }
    }
}
