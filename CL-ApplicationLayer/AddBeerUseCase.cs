﻿using CL_EnterpriseLayer;
using System.ComponentModel.DataAnnotations;

namespace CL_ApplicationLayer
{
    public class AddBeerUseCase<TDTO>
    {
        private readonly IRepository<Beer> _beerRepository;
        private readonly IMapper<TDTO, Beer> _mapper;

        public AddBeerUseCase(IRepository<Beer> beerRepository,
            IMapper<TDTO, Beer> mapper)
        {
            _beerRepository = beerRepository;
            _mapper = mapper;
        }
        public async Task ExecuteAsync(TDTO beerDTO)
        {
            var beer = _mapper.ToEntity(beerDTO);

            if (string.IsNullOrEmpty(beer.Name))
                throw new ValidationException("El nombre de la cerveza es obligatorio.");

            await _beerRepository.AddAsync(beer);
        }
    }
}
