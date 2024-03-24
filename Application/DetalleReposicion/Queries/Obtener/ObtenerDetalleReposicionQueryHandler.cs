using Application.DetalleReposicion.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleReposicion.Queries.Obtener
{
    public class ObtenerDetalleReposicionQueryHandler : IRequestHandler<ObtenerDetalleReposicionQuery, DetalleReposicionDTO>
    {
        private readonly IDetalleReposicionRepository _DetalleReposicionRepository;
        private readonly IMapper _mapper;

        public ObtenerDetalleReposicionQueryHandler(IDetalleReposicionRepository DetalleReposicionRepository, IMapper mapper)
        {
            _DetalleReposicionRepository = DetalleReposicionRepository;
            _mapper = mapper;
        }

        public async Task<DetalleReposicionDTO> Handle(ObtenerDetalleReposicionQuery request, CancellationToken cancellationToken)
        {
            var variable = await _DetalleReposicionRepository.ObtenerDetalleReposicion(request.Id);
            return _mapper.Map<DetalleReposicionDTO>(variable);
        }
    }
}

