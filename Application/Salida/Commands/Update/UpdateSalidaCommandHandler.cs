using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Salida.Commands.Update
{
    public class UpdateSalidaCommandHandler : IRequestHandler<UpdateSalidaCommand, Unit>
    {
        private readonly ISalidaRepository _repos;
        private readonly IMapper _mapper;

        public UpdateSalidaCommandHandler(ISalidaRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSalidaCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateSalidaCommand, SalidaEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<SalidaEntity>(request);

            await _repos.ActualizarSalida(Entity);

            return Unit.Value;
        }
    }
}

