using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleReposicion.Queries.Listar
{
    public class ListarDetalleReposicionQueryHandler : IRequestHandler<ListarDetalleReposicionQuery, IEnumerable<DetalleReposicionDTO>>
    {
        private readonly IDetalleReposicionRepository _repository;
        private readonly IMapper _mapper;

        public ListarDetalleReposicionQueryHandler(IDetalleReposicionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetalleReposicionDTO>> Handle(ListarDetalleReposicionQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarDetalleReposicion();
            return _mapper.Map<IEnumerable<DetalleReposicionDTO>>(lista);
        }
    }
}

