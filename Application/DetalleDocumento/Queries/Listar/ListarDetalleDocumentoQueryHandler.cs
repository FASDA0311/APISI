using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleDocumento.Queries.Listar
{
    public class ListarDetalleDocumentoQueryHandler : IRequestHandler<ListarDetalleDocumentoQuery, IEnumerable<DetalleDocumentoDTO>>
    {
        private readonly IDocumentoRepository _repository;
        private readonly IMapper _mapper;

        public ListarDetalleDocumentoQueryHandler(IDocumentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetalleDocumentoDTO>> Handle(ListarDetalleDocumentoQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarDocumento();
            return _mapper.Map<IEnumerable<DetalleDocumentoDTO>>(lista);
        }
    }
}
