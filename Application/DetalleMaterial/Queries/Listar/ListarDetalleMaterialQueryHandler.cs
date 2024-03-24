using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleMaterial.Queries.Listar
{
    public class ListarDetalleMaterialQueryHandler : IRequestHandler<ListarDetalleMaterialQuery, IEnumerable<DetalleMaterialDTO>>
    {
        private readonly IDetalleMaterialRepository _repository;
        private readonly IMapper _mapper;

        public ListarDetalleMaterialQueryHandler(IDetalleMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetalleMaterialDTO>> Handle(ListarDetalleMaterialQuery request, CancellationToken cancellationToken)
        {
            var lista = await _repository.ListarDetalleMaterial();
            return _mapper.Map<IEnumerable<DetalleMaterialDTO>>(lista);
        }
    }
}

