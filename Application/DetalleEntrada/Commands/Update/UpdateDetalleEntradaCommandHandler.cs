using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleEntrada.Commands.Update
{
    public class UpdateDetalleEntradaCommandHandler : IRequestHandler<UpdateDetalleEntradaCommand, Unit>
    {
        private readonly IDetalleEntradaRepository _repos;
        private readonly IMapper _mapper;

        public UpdateDetalleEntradaCommandHandler(IDetalleEntradaRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDetalleEntradaCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateDetalleEntradaCommand, DetalleEntradaEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<DetalleEntradaEntity>(request);

            await _repos.ActualizarDetalleEntrada(Entity);

            return Unit.Value;
        }
    }
}

