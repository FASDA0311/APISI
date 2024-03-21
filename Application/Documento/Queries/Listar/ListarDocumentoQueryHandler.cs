using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documento.Queries.Listar
{
    public class ListarDocumentoQueryHandler : IRequestHandler<ListarDocumentoQuery, IEnumerable<DocumentoDTO>>
    {
        private readonly IDocumentoRepository _repository;
        private readonly IMapper _mapper;

        public ListarDocumentoQueryHandler(IDocumentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DocumentoDTO>> Handle(ListarDocumentoQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarDocumento();
            return _mapper.Map<IEnumerable<DocumentoDTO>>(lista);
        }
    }
}
