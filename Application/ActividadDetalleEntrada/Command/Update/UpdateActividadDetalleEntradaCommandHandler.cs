using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActividadDetalleEntrada.Commands.Update
{
    public class UpdateActividadDetalleEntradaCommandHandler : IRequestHandler<UpdateActividadDetalleEntradaCommand, Unit>
    {
        private readonly IActividadDetalleEntradaRepository _repos;
        private readonly IMapper _mapper;

        public UpdateActividadDetalleEntradaCommandHandler(IActividadDetalleEntradaRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateActividadDetalleEntradaCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateActividadDetalleEntradaCommand, ActividadDetalleEntradaEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<ActividadDetalleEntradaEntity>(request);

            await _repos.ActualizarActividadDetalleEntrada(Entity);

            return Unit.Value;
        }
    }
}

