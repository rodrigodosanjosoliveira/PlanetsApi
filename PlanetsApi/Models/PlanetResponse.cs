using System.Collections.Generic;
using System.Linq;

namespace PlanetsApi.Models
{
    public class PlanetResponse
    {
        public List<Result> Results { get; set; }

        public int ApparitionsCount()
        {
            if (Results == null)
                return 0;
            return Results.First().Films.Count;
        }
    }

    public class Result
    {
        public List<string> Films { get; set; }
    }
}
