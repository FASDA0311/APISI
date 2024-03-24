using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleEntrada.Queries.Listar
{
    public class ListarDetalleEntradaQueryHandler : IRequestHandler<ListarDetalleEntradaQuery, IEnumerable<DetalleEntradaDTO>>
    {
        private readonly IDetalleEntradaRepository _repository;
        private readonly IMapper _mapper;

        public ListarDetalleEntradaQueryHandler(IDetalleEntradaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetalleEntradaDTO>> Handle(ListarDetalleEntradaQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarDetalleEntrada();
            return _mapper.Map<IEnumerable<DetalleEntradaDTO>>(lista);
        }
    }
}

