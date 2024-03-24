using Application.DetalleDocumento.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleDocumento.Queries.Obtener
{
    public class ObtenerDetalleDocumentoQueryHandler : IRequestHandler<ObtenerDetalleDocumentoQuery, DetalleDocumentoDTO>
    {
        private readonly IDetalleDocumentoRepository _DetalleDocumentoRepository;
        private readonly IMapper _mapper;

        public ObtenerDetalleDocumentoQueryHandler(IDetalleDocumentoRepository DetalleDocumentoRepository, IMapper mapper)
        {
            _DetalleDocumentoRepository = DetalleDocumentoRepository;
            _mapper = mapper;
        }

        public async Task<DetalleDocumentoDTO> Handle(ObtenerDetalleDocumentoQuery request, CancellationToken cancellationToken)
        {
            var variable = await _DetalleDocumentoRepository.ObtenerDetalleDocumento(request.Id);
            return _mapper.Map<DetalleDocumentoDTO>(variable);
        }
    }
}

