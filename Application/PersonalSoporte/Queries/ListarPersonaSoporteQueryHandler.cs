using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalSoporte.Queries
{
    public class ListarPersonaSoporteQueryHandler : IRequestHandler<ListarPersonaSoporteQuery, IEnumerable<PersonalSoporteDTO>>
    {
        private readonly IPersonalSoporteRepository _repository;
        private readonly IMapper _mapper;

        public ListarPersonaSoporteQueryHandler(IPersonalSoporteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonalSoporteDTO>> Handle(ListarPersonaSoporteQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarPersonalSoporte();
            return _mapper.Map<IEnumerable<PersonalSoporteDTO>>(lista);
        }
    }
}
