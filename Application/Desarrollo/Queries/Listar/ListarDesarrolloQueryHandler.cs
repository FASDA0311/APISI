using Application.Actividad.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Desarrollo.Queries.Listar
{
    public class ListarDesarrolloQueryHandler : IRequestHandler<ListarDesarrolloQuery, IEnumerable<DesarrolloDTO>>
    {
        private readonly IDesarrolloRepository _repository;
        private readonly IMapper _mapper;

        public ListarDesarrolloQueryHandler(IDesarrolloRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DesarrolloDTO>> Handle(ListarDesarrolloQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarDesarrollo();
            return _mapper.Map<IEnumerable<DesarrolloDTO>>(lista);
        }
    }
}

