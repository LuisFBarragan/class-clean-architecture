using CL_ApplicationLayer;
using CL_EnterpriseLayer;

namespace CL_InterfaceAdapters_Presenters
{
    public class BeerPresenter : IPresenter<Beer, BeerViewModel>
    {
        public IEnumerable<BeerViewModel> Present(IEnumerable<Beer> beers)
            => beers.Select(b=> new BeerViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Alcohol = b.Alcohol + " %"
            });
    }
}
