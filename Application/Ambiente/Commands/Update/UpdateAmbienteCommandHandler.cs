using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ambiente.Commands.Update
{
    public class UpdateAmbienteCommandHandler : IRequestHandler<UpdateAmbienteCommand, Unit>
    {
        private readonly IAmbienteRepository _repos;
        private readonly IMapper _mapper;

        public UpdateAmbienteCommandHandler(IAmbienteRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAmbienteCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateAmbienteCommand, AmbienteEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<AmbienteEntity>(request);

            await _repos.ActualizarAmbiente(Entity);

            return Unit.Value;
        }
    }
}

