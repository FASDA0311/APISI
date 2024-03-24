using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Salida.Queries.Listar
{
    public class ListarSalidaQueryHandler : IRequestHandler<ListarSalidaQuery, IEnumerable<SalidaDTO>>
    {
        private readonly ISalidaRepository _repository;
        private readonly IMapper _mapper;

        public ListarSalidaQueryHandler(ISalidaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SalidaDTO>> Handle(ListarSalidaQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarSalida();
            return _mapper.Map<IEnumerable<SalidaDTO>>(lista);
        }
    }
}

