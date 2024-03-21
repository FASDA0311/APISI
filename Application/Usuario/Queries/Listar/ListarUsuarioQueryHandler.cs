using Application.Common.Interfaces.Repositorios;
using Application.Usuario.Queries.Listar;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuario.Queries.Listar
{
    public class ListarDetalleDocumentoQueryHandler : IRequestHandler<ListarUsuarioQuery, IEnumerable<UsuarioDTO>>
    {
        private readonly IDocumentoRepository _repository;
        private readonly IMapper _mapper;

        public ListarDetalleDocumentoQueryHandler(IDocumentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> Handle(ListarUsuarioQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarDocumento();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(lista);
        }
    }
}
