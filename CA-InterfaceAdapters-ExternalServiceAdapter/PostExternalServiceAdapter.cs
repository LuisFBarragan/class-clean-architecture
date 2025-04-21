using CA_InterfaceAdapters_Adapters.Dtos;
using CL_ApplicationLayer;
using CL_EnterpriseLayer;
using System.Text.Json;

namespace CA_InterfaceAdapters_Adapters
{
    public class PostExternalServiceAdapter : IExternalServiceAdapter<Post>
    {
        private readonly IExternalService<PostServiceDto> _externalService;

        public PostExternalServiceAdapter(IExternalService<PostServiceDto> externalService)
            => _externalService = externalService;

        public async Task<IEnumerable<Post>> GetDataAsync()
        {
            var postsES = await _externalService.GetContentAsync();
            var posts = postsES.Select(p => new Post {
                Id = p.Id,
                Title = p.Title,
                Body = p.Body
            });
            return posts;
        }
    }
}
