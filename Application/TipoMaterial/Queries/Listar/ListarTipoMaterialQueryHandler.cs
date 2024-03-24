using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TipoMaterial.Queries.Listar
{
    public class ListarTipoMaterialQueryHandler : IRequestHandler<ListarTipoMaterialQuery, IEnumerable<TipoMaterialDTO>>
    {
        private readonly ITipoMaterialRepository _repository;
        private readonly IMapper _mapper;

        public ListarTipoMaterialQueryHandler(ITipoMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoMaterialDTO>> Handle(ListarTipoMaterialQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarTipoMaterial();
            return _mapper.Map<IEnumerable<TipoMaterialDTO>>(lista);
        }
    }
}

