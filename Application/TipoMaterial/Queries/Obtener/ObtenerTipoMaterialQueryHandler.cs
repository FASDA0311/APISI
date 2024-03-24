using Application.TipoMaterial.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TipoMaterial.Queries.Obtener
{
    public class ObtenerTipoMaterialQueryHandler : IRequestHandler<ObtenerTipoMaterialQuery, TipoMaterialDTO>
    {
        private readonly ITipoMaterialRepository _TipoMaterialRepository;
        private readonly IMapper _mapper;

        public ObtenerTipoMaterialQueryHandler(ITipoMaterialRepository TipoMaterialRepository, IMapper mapper)
        {
            _TipoMaterialRepository = TipoMaterialRepository;
            _mapper = mapper;
        }

        public async Task<TipoMaterialDTO> Handle(ObtenerTipoMaterialQuery request, CancellationToken cancellationToken)
        {
            var variable = await _TipoMaterialRepository.ObtenerTipoMaterial(request.Id);
            return _mapper.Map<TipoMaterialDTO>(variable);
        }
    }
}

