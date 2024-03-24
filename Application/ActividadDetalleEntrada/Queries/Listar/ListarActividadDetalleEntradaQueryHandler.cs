using Application.Common.Interfaces.Repositorios;
using Application.PersonalSoporte.Queries;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActividadDetalleEntrada.Queries.Listar
{
    public class ListarActividadDetalleEntradaQueryHandler : IRequestHandler<ListarActividadDetalleEntradaQuery, IEnumerable<ActividadDetalleEntradaDTO>>
    {
        private readonly IActividadDetalleEntradaRepository _repository;
        private readonly IMapper _mapper;

        public ListarActividadDetalleEntradaQueryHandler(IActividadDetalleEntradaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActividadDetalleEntradaDTO>> Handle(ListarActividadDetalleEntradaQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarActividadDetalleEntrada();
            return _mapper.Map<IEnumerable<ActividadDetalleEntradaDTO>>(lista);
        }
    }
}

