using CL_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_ApplicationLayer
{
    public class GetBeerUseCase<TEntity, TOutput> 
    {
        private readonly IRepository<TEntity> _beerRepository;
        private readonly IPresenter<TEntity, TOutput> _presenter;

        public GetBeerUseCase(IRepository<TEntity> beerRepository,
            IPresenter<TEntity, TOutput> presenter)
        {
            _beerRepository = beerRepository;
            _presenter = presenter;
        }

        public async Task<IEnumerable<TOutput>> ExecuteAsync()
        {
            var beers = await _beerRepository.GetAllAsync();
            return _presenter.Present(beers);
        }

    }
}
