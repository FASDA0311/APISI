using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entrada.Queries.Listar
{
    public class ListarEntradaQueryHandler : IRequestHandler<ListarEntradaQuery, IEnumerable<EntradaDTO>>
    {
        private readonly IEntradaRepository _repository;
        private readonly IMapper _mapper;

        public ListarEntradaQueryHandler(IEntradaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntradaDTO>> Handle(ListarEntradaQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarEntrada();
            return _mapper.Map<IEnumerable<EntradaDTO>>(lista);
        }
    }
}

