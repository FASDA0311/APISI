using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actividad.Commands.Update
{
    public class UpdateActividadCommandHandler : IRequestHandler<UpdateActividadCommand, Unit>
    {
        private readonly IActividadRepository _repos;
        private readonly IMapper _mapper;

        public UpdateActividadCommandHandler(IActividadRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateActividadCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateActividadCommand, ActividadEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<ActividadEntity>(request);

            await _repos.ActualizarActividad(Entity);

            return Unit.Value;
        }
    }
}
