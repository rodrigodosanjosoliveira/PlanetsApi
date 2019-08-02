namespace PlanetsApi.Models
{

    public class Planet : EntityBase
    {
        public Planet(string name, string climate, string terrain)
        {
            Name = name;
            Terrain = terrain;
            Climate = climate;
        }

        public string Name { get; private set; }
        public string Terrain { get; private set; }
        public string Climate { get; private set; }
        public int ApparitionsInFilms { get; set; }
    }
}
