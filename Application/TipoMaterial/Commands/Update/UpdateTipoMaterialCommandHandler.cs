using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TipoMaterial.Commands.Update
{
    public class UpdateTipoMaterialCommandHandler : IRequestHandler<UpdateTipoMaterialCommand, Unit>
    {
        private readonly ITipoMaterialRepository _repos;
        private readonly IMapper _mapper;

        public UpdateTipoMaterialCommandHandler(ITipoMaterialRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTipoMaterialCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateTipoMaterialCommand, TipoMaterialEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<TipoMaterialEntity>(request);

            await _repos.ActualizarTipoMaterial(Entity);

            return Unit.Value;
        }
    }
}

