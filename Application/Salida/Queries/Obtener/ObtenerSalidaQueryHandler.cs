using Application.Salida.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Salida.Queries.Obtener
{
    public class ObtenerSalidaQueryHandler : IRequestHandler<ObtenerSalidaQuery, SalidaDTO>
    {
        private readonly ISalidaRepository _SalidaRepository;
        private readonly IMapper _mapper;

        public ObtenerSalidaQueryHandler(ISalidaRepository SalidaRepository, IMapper mapper)
        {
            _SalidaRepository = SalidaRepository;
            _mapper = mapper;
        }

        public async Task<SalidaDTO> Handle(ObtenerSalidaQuery request, CancellationToken cancellationToken)
        {
            var variable = await _SalidaRepository.ObtenerSalida(request.Id);
            return _mapper.Map<SalidaDTO>(variable);
        }
    }
}

