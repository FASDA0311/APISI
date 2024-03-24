using Application.Entrada.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entrada.Queries.Obtener
{
    public class ObtenerEntradaQueryHandler : IRequestHandler<ObtenerEntradaQuery, EntradaDTO>
    {
        private readonly IEntradaRepository _EntradaRepository;
        private readonly IMapper _mapper;

        public ObtenerEntradaQueryHandler(IEntradaRepository EntradaRepository, IMapper mapper)
        {
            _EntradaRepository = EntradaRepository;
            _mapper = mapper;
        }

        public async Task<EntradaDTO> Handle(ObtenerEntradaQuery request, CancellationToken cancellationToken)
        {
            var variable = await _EntradaRepository.ObtenerEntrada(request.Id);
            return _mapper.Map<EntradaDTO>(variable);
        }
    }
}

