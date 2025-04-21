using BusinessComponent;

namespace RepositoryComponent
{
    public class BeerRepository : IRepository
    {
        private List<string> _beers;

        public BeerRepository()
            => _beers = new List<string>();

        public void Add(string name)
            => _beers.Add(name);

        public string Get()
            => _beers.Aggregate("", (ac, beer) => ac + beer +", ");
    }
}
