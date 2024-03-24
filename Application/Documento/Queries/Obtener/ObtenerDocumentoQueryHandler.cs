using Application.Documento.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documento.Queries.Obtener
{
    public class ObtenerDocumentoQueryHandler : IRequestHandler<ObtenerDocumentoQuery, DocumentoDTO>
    {
        private readonly IDocumentoRepository _DocumentoRepository;
        private readonly IMapper _mapper;

        public ObtenerDocumentoQueryHandler(IDocumentoRepository DocumentoRepository, IMapper mapper)
        {
            _DocumentoRepository = DocumentoRepository;
            _mapper = mapper;
        }

        public async Task<DocumentoDTO> Handle(ObtenerDocumentoQuery request, CancellationToken cancellationToken)
        {
            var variable = await _DocumentoRepository.ObtenerDocumento(request.Id);
            return _mapper.Map<DocumentoDTO>(variable);
        }
    }
}

