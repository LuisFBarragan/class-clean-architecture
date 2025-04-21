using CL_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_ApplicationLayer
{
    public class GetPostUseCase
    {
        private readonly IExternalServiceAdapter<Post> _adapter;

        public GetPostUseCase(IExternalServiceAdapter<Post> adapter)
            => _adapter = adapter;

        public async Task<IEnumerable<Post>> ExecuteAsync()
            => await _adapter.GetDataAsync();


    }
}
