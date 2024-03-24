using Application.Responsable.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responsable.Queries.Obtener
{
    public class ObtenerResponsableQueryHandler : IRequestHandler<ObtenerResponsableQuery, ResponsableDTO>
    {
        private readonly IResponsableRepository _ResponsableRepository;
        private readonly IMapper _mapper;

        public ObtenerResponsableQueryHandler(IResponsableRepository ResponsableRepository, IMapper mapper)
        {
            _ResponsableRepository = ResponsableRepository;
            _mapper = mapper;
        }

        public async Task<ResponsableDTO> Handle(ObtenerResponsableQuery request, CancellationToken cancellationToken)
        {
            var variable = await _ResponsableRepository.ObtenerResponsable(request.Id);
            return _mapper.Map<ResponsableDTO>(variable);
        }
    }
}

