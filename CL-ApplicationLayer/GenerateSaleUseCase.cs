using CL_ApplicationLayer.Exceptions;
using CL_EnterpriseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_ApplicationLayer
{
    public class GenerateSaleUseCase<TDTO>
    {
        private IRepository<Sale> _repository;
        private readonly IMapper<TDTO, Sale> _mapper;

        public GenerateSaleUseCase(IRepository<Sale> repository, IMapper<TDTO, Sale> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(TDTO saleDTO)
        {
            var sale = _mapper.ToEntity(saleDTO);

            if (sale.Concepts.Count == 0)
            {
                throw new ValidationException("Una venta debe tener conceptos.");
            }
            if (sale.Total <= 0)
            {
                throw new ValidationException("Una venta debe tener más de $ 0.00 en total.");
            }

            await _repository.AddAsync(sale);
        }
    }
}
