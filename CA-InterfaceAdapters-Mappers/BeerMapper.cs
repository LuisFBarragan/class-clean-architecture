using CA_InterfaceAdapters_Mappers.Dtos.Requests;
using CL_ApplicationLayer;
using CL_EnterpriseLayer;

namespace CA_InterfaceAdapters_Mappers
{
    public class BeerMapper : IMapper<BeerRequestDTO, Beer>
    {
        public Beer ToEntity(BeerRequestDTO dto)
            => new Beer()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Style = dto.Style,
                    Alcohol = dto.Alcohol
                };
        
    }
}
