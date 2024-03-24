using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleMaterial.Commands.Update
{
    public class UpdateDetalleMaterialCommandHandler : IRequestHandler<UpdateDetalleMaterialCommand, Unit>
    {
        private readonly IDetalleMaterialRepository _repos;
        private readonly IMapper _mapper;

        public UpdateDetalleMaterialCommandHandler(IDetalleMaterialRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDetalleMaterialCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateDetalleMaterialCommand, DetalleMaterialEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<DetalleMaterialEntity>(request);

            await _repos.ActualizarDetalleMaterial(Entity);

            return Unit.Value;
        }
    }
}

