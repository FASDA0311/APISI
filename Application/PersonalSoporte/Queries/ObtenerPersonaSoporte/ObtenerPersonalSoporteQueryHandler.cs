using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalSoporte.Queries.ObtenerPersonaSoporte
{
    public class ObtenerPersonalSoporteQueryHandler : IRequestHandler<ObtenerPersonalSoporteQuery, PersonalSoporteDTO>
    {
        private readonly IPersonalSoporteRepository _personalSoporteRepository;
        private readonly IMapper _mapper;

        public ObtenerPersonalSoporteQueryHandler(IPersonalSoporteRepository personalSoporteRepository, IMapper mapper)
        {
            _personalSoporteRepository = personalSoporteRepository;
            _mapper = mapper;
        }

        public async Task<PersonalSoporteDTO> Handle(ObtenerPersonalSoporteQuery request, CancellationToken cancellationToken)
        {
            var variable = await _personalSoporteRepository.ObtenerPersonalSoporte(request.Id);
            return _mapper.Map<PersonalSoporteDTO>(variable);
        }
    }
}
