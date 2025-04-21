
namespace BeersRepositoryComponent
{
    public class Beers
    {
        private List<string> _beers;
        public Beers()
            => _beers = new List<string>();

        public void Add(string beer)
            => _beers.Add(beer);

    }
}
