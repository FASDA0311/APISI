using Application.DetalleEntrada.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleEntrada.Queries.Obtener
{
    public class ObtenerDetalleEntradaQueryHandler : IRequestHandler<ObtenerDetalleEntradaQuery, DetalleEntradaDTO>
    {
        private readonly IDetalleEntradaRepository _DetalleEntradaRepository;
        private readonly IMapper _mapper;

        public ObtenerDetalleEntradaQueryHandler(IDetalleEntradaRepository DetalleEntradaRepository, IMapper mapper)
        {
            _DetalleEntradaRepository = DetalleEntradaRepository;
            _mapper = mapper;
        }

        public async Task<DetalleEntradaDTO> Handle(ObtenerDetalleEntradaQuery request, CancellationToken cancellationToken)
        {
            var variable = await _DetalleEntradaRepository.ObtenerDetalleEntrada(request.Id);
            return _mapper.Map<DetalleEntradaDTO>(variable);
        }
    }
}

