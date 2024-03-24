using Application.Actividad.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actividad.Queries.Obtener
{
    public class ObtenerActividadQueryHandler : IRequestHandler<ObtenerActividadQuery, ActividadDTO>
    {
        private readonly IActividadRepository _ActividadRepository;
        private readonly IMapper _mapper;

        public ObtenerActividadQueryHandler(IActividadRepository ActividadRepository, IMapper mapper)
        {
            _ActividadRepository = ActividadRepository;
            _mapper = mapper;
        }

        public async Task<ActividadDTO> Handle(ObtenerActividadQuery request, CancellationToken cancellationToken)
        {
            var variable = await _ActividadRepository.ObtenerActividad(request.Id);
            return _mapper.Map<ActividadDTO>(variable);
        }
    }
}

