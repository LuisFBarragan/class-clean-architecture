namespace BusinessComponent
{
    public class BeerManager
    {
        private IRepository _repository;
        public BeerManager(IRepository repository)
           => _repository = repository;

        public void Add(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            
            _repository.Add(name);

        }
        public string Get()
           => "Las cervezas son: " + _repository.Get();
    }
}
