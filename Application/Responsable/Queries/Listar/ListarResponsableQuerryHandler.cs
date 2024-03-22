using Application.Common.Interfaces.Repositorios;
using Application.Equipo.Queries.Listar;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responsable.Queries.Listar
{
    public class ListarResponsableQuerryHandler : IRequestHandler<ListarResponsableQuery, IEnumerable<ResponsableDTO>>
    {
        private readonly IResponsableRepository _repository;
        private readonly IMapper _mapper;

        public ListarResponsableQuerryHandler(IResponsableRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResponsableDTO>> Handle(ListarResponsableQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarResponsable();
            return _mapper.Map<IEnumerable<ResponsableDTO>>(lista);
        }
    }
}
