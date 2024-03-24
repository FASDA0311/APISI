using Application.Ambiente.Queries;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ambiente.Queries.Obtener
{
    public class ObtenerAmbienteQueryHandler : IRequestHandler<ObtenerAmbienteQuery, AmbienteDTO>
    {
        private readonly IAmbienteRepository _AmbienteRepository;
        private readonly IMapper _mapper;

        public ObtenerAmbienteQueryHandler(IAmbienteRepository AmbienteRepository, IMapper mapper)
        {
            _AmbienteRepository = AmbienteRepository;
            _mapper = mapper;
        }

        public async Task<AmbienteDTO> Handle(ObtenerAmbienteQuery request, CancellationToken cancellationToken)
        {
            var variable = await _AmbienteRepository.ObtenerAmbiente(request.Id);
            return _mapper.Map<AmbienteDTO>(variable);
        }
    }
}

