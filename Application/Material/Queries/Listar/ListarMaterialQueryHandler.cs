using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Material.Queries.Listar
{
    public class ListarMaterialQueryHandler : IRequestHandler<ListarMaterialQuery, IEnumerable<MaterialDTO>>
    {
        private readonly IMaterialRepository _repository;
        private readonly IMapper _mapper;

        public ListarMaterialQueryHandler(IMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialDTO>> Handle(ListarMaterialQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarMaterial();
            return _mapper.Map<IEnumerable<MaterialDTO>>(lista);
        }
    }
}

