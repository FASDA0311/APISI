using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TipoMaterial.Commands.Crear
{
    public class CreateTipoMaterialCommandHandler : IRequestHandler<CreateTipoMaterialCommand, int>
    {
        private readonly ITipoMaterialRepository _repository;
        private readonly IMapper _mapper;

        public CreateTipoMaterialCommandHandler(ITipoMaterialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTipoMaterialCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateTipoMaterialCommand, TipoMaterialEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<TipoMaterialEntity>(request);

            var datoComunId = await _repository.CrearTipoMaterial(Entity);

            return datoComunId;
        }
    }
}

