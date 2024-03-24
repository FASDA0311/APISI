using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Desarrollo.Commands.Update
{
    public class UpdateDesarrolloCommandHandler : IRequestHandler<UpdateDesarrolloCommand, Unit>
    {
        private readonly IDesarrolloRepository _repos;
        private readonly IMapper _mapper;

        public UpdateDesarrolloCommandHandler(IDesarrolloRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDesarrolloCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateDesarrolloCommand, DesarrolloEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<DesarrolloEntity>(request);

            await _repos.ActualizarDesarrollo(Entity);

            return Unit.Value;
        }
    }
}

