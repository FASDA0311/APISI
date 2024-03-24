using Application.DetalleMaterial.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleMaterial.Queries.Obtener
{
    public class ObtenerDetalleMaterialQueryHandler : IRequestHandler<ObtenerDetalleMaterialQuery, DetalleMaterialDTO>
    {
        private readonly IDetalleMaterialRepository _DetalleMaterialRepository;
        private readonly IMapper _mapper;

        public ObtenerDetalleMaterialQueryHandler(IDetalleMaterialRepository DetalleMaterialRepository, IMapper mapper)
        {
            _DetalleMaterialRepository = DetalleMaterialRepository;
            _mapper = mapper;
        }

        public async Task<DetalleMaterialDTO> Handle(ObtenerDetalleMaterialQuery request, CancellationToken cancellationToken)
        {
            var variable = await _DetalleMaterialRepository.ObtenerDetalleMaterial(request.Id);
            return _mapper.Map<DetalleMaterialDTO>(variable);
        }
    }
}

