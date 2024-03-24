using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Equipo.Commands.Update
{
    public class UpdateEquipoCommandHandler : IRequestHandler<UpdateEquipoCommand, Unit>
    {
        private readonly IEquipoRepository _repos;
        private readonly IMapper _mapper;

        public UpdateEquipoCommandHandler(IEquipoRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEquipoCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateEquipoCommand, EquipoEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<EquipoEntity>(request);

            await _repos.ActualizarEquipo(Entity);

            return Unit.Value;
        }
    }
}

