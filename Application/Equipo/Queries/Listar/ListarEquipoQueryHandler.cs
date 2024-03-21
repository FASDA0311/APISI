using Application.Ambiente.Queries;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Equipo.Queries.Listar
{
    public class ListarEquipoQueryHandler : IRequestHandler<ListarEquipoQuery, IEnumerable<EquipoDTO>>
    {
        private readonly IEquipoRepository _repository;
        private readonly IMapper _mapper;

        public ListarEquipoQueryHandler(IEquipoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EquipoDTO>> Handle(ListarEquipoQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarEquipo();
            return _mapper.Map<IEnumerable<EquipoDTO>>(lista);
        }
    }
}
