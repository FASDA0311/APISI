using Application.PersonalDesarrollo.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalDesarrollo.Queries.Obtener
{
    public class ObtenerPersonalDesarrolloQueryHandler : IRequestHandler<ObtenerPersonalDesarrolloQuery, PersonalDesarrolloDTO>
    {
        private readonly IPersonalDesarrolloRepository _PersonalDesarrolloRepository;
        private readonly IMapper _mapper;

        public ObtenerPersonalDesarrolloQueryHandler(IPersonalDesarrolloRepository PersonalDesarrolloRepository, IMapper mapper)
        {
            _PersonalDesarrolloRepository = PersonalDesarrolloRepository;
            _mapper = mapper;
        }

        public async Task<PersonalDesarrolloDTO> Handle(ObtenerPersonalDesarrolloQuery request, CancellationToken cancellationToken)
        {
            var variable = await _PersonalDesarrolloRepository.ObtenerPersonalDesarrollo(request.Id);
            return _mapper.Map<PersonalDesarrolloDTO>(variable);
        }
    }
}

