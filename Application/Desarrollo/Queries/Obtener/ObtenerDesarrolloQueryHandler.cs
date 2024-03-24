using Application.Desarrollo.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Desarrollo.Queries.Obtener
{
    public class ObtenerDesarrolloQueryHandler : IRequestHandler<ObtenerDesarrolloQuery, DesarrolloDTO>
    {
        private readonly IDesarrolloRepository _DesarrolloRepository;
        private readonly IMapper _mapper;

        public ObtenerDesarrolloQueryHandler(IDesarrolloRepository DesarrolloRepository, IMapper mapper)
        {
            _DesarrolloRepository = DesarrolloRepository;
            _mapper = mapper;
        }

        public async Task<DesarrolloDTO> Handle(ObtenerDesarrolloQuery request, CancellationToken cancellationToken)
        {
            var variable = await _DesarrolloRepository.ObtenerDesarrollo(request.Id);
            return _mapper.Map<DesarrolloDTO>(variable);
        }
    }
}

