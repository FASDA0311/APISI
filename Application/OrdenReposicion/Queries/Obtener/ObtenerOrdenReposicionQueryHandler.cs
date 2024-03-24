using Application.OrdenReposicion.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrdenReposicion.Queries.Obtener
{
    public class ObtenerOrdenReposicionQueryHandler : IRequestHandler<ObtenerOrdenReposicionQuery, OrdenReposicionDTO>
    {
        private readonly IOrdenReposicionRepository _OrdenReposicionRepository;
        private readonly IMapper _mapper;

        public ObtenerOrdenReposicionQueryHandler(IOrdenReposicionRepository OrdenReposicionRepository, IMapper mapper)
        {
            _OrdenReposicionRepository = OrdenReposicionRepository;
            _mapper = mapper;
        }

        public async Task<OrdenReposicionDTO> Handle(ObtenerOrdenReposicionQuery request, CancellationToken cancellationToken)
        {
            var variable = await _OrdenReposicionRepository.ObtenerOrdenReposicion(request.Id);
            return _mapper.Map<OrdenReposicionDTO>(variable);
        }
    }
}
