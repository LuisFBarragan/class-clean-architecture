using CA_InterfaceAdapters_Mappers.Dtos.Requests;
using CL_ApplicationLayer;
using CL_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_InterfaceAdapters_Mappers
{
    public class SaleMapper : IMapper<SaleRequestDTO, Sale>
    {
        public Sale ToEntity(SaleRequestDTO dto)
        {
          
            var concepts = new List<Concept>();

            foreach (var conceptDTO in dto.Concepts)
            {
                concepts.Add(new Concept(conceptDTO.Quantity, conceptDTO.IdBeer, conceptDTO.UnitPrice));
            }

            return new Sale(DateTime.Now, concepts);
        }
    }
}
