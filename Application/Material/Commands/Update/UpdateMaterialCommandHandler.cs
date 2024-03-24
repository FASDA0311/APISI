using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Material.Commands.Update
{
    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand, Unit>
    {
        private readonly IMaterialRepository _repos;
        private readonly IMapper _mapper;

        public UpdateMaterialCommandHandler(IMaterialRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateMaterialCommand, MaterialEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<MaterialEntity>(request);

            await _repos.ActualizarMaterial(Entity);

            return Unit.Value;
        }
    }
}
