using CL_ApplicationLayer;
using CL_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_InterfaceAdapters_Presenters
{
    public class BeerDetailPresenter : IPresenter<Beer, BeerDetailViewModel>
    {
        public IEnumerable<BeerDetailViewModel> Present(IEnumerable<Beer> beers)
            => beers.Select(b => new BeerDetailViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Alcohol = b.Alcohol + " %",
                Color = b.IsStrongBeer() ? "red" : "green",
                Style = b.Style,
                Message = b.IsStrongBeer() ? "Cerveza fuerte" : ""
            });
    }
}
