using PlanetsApi.Models;
using PlanetsApi.Repository.Context;
using PlanetsApi.Repository.Interfaces;

namespace PlanetsApi.Repository
{
    public class PlanetRepository : RepositoryBase<Planet>, IPlanetRepository
    {
        public PlanetRepository(MyContext myContext)
            : base(myContext) { }
    }
}
