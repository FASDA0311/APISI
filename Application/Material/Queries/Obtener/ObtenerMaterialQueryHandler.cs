using Application.Material.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Material.Queries.Obtener
{
    public class ObtenerMaterialQueryHandler : IRequestHandler<ObtenerMaterialQuery, MaterialDTO>
    {
        private readonly IMaterialRepository _MaterialRepository;
        private readonly IMapper _mapper;

        public ObtenerMaterialQueryHandler(IMaterialRepository MaterialRepository, IMapper mapper)
        {
            _MaterialRepository = MaterialRepository;
            _mapper = mapper;
        }

        public async Task<MaterialDTO> Handle(ObtenerMaterialQuery request, CancellationToken cancellationToken)
        {
            var variable = await _MaterialRepository.ObtenerMaterial(request.Id);
            return _mapper.Map<MaterialDTO>(variable);
        }
    }
}

