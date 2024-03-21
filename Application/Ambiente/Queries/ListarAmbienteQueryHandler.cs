using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ambiente.Queries
{
    public class ListarAmbienteQueryHandler : IRequestHandler<ListarAmbienteQuery, IEnumerable<AmbienteDTO>>
    {
        private readonly IAmbienteRepository _repository;
        private readonly IMapper _mapper;

        public ListarAmbienteQueryHandler(IAmbienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AmbienteDTO>> Handle(ListarAmbienteQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarAmbiente();
            return _mapper.Map<IEnumerable<AmbienteDTO>>(lista);
        }
    }
}
