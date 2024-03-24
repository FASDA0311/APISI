using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrdenReposicion.Queries.Listar
{
    public class ListarOrdenReposicionQueryHandler : IRequestHandler<ListarOrdenReposicionQuery, IEnumerable<OrdenReposicionDTO>>
    {
        private readonly IOrdenReposicionRepository _repository;
        private readonly IMapper _mapper;

        public ListarOrdenReposicionQueryHandler(IOrdenReposicionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrdenReposicionDTO>> Handle(ListarOrdenReposicionQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarOrdenReposicion();
            return _mapper.Map<IEnumerable<OrdenReposicionDTO>>(lista);
        }
    }
}

