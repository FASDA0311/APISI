using Application.Equipo.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Equipo.Queries.Obtener
{
    public class ObtenerEquipoQueryHandler : IRequestHandler<ObtenerEquipoQuery, EquipoDTO>
    {
        private readonly IEquipoRepository _EquipoRepository;
        private readonly IMapper _mapper;

        public ObtenerEquipoQueryHandler(IEquipoRepository EquipoRepository, IMapper mapper)
        {
            _EquipoRepository = EquipoRepository;
            _mapper = mapper;
        }

        public async Task<EquipoDTO> Handle(ObtenerEquipoQuery request, CancellationToken cancellationToken)
        {
            var variable = await _EquipoRepository.ObtenerEquipo(request.Id);
            return _mapper.Map<EquipoDTO>(variable);
        }
    }
}

