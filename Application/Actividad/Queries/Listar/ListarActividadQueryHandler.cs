using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actividad.Queries.Listar
{
    public class ListarActividadQueryHandler : IRequestHandler<ListarActividadQuery, IEnumerable<ActividadDTO>>
    {
        private readonly IActividadRepository _repository;
        private readonly IMapper _mapper;

        public ListarActividadQueryHandler(IActividadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActividadDTO>> Handle(ListarActividadQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarActividad();
            return _mapper.Map<IEnumerable<ActividadDTO>>(lista);
        }
    }
}

