using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleMaterial.Commands.Crear
{
    public class CreateDetalleMaterialCommandHandler : IRequestHandler<CreateDetalleMaterialCommand, int>
    {
        private readonly IDetalleMaterialRepository _repository;
        private readonly IMapper _mapper;

        public CreateDetalleMaterialCommandHandler(IDetalleMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDetalleMaterialCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateDetalleMaterialCommand, DetalleMaterialEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<DetalleMaterialEntity>(request);

            var datoComunId = await _repository.CrearDetalleMaterial(Entity);

            return datoComunId;
        }
    }
}

