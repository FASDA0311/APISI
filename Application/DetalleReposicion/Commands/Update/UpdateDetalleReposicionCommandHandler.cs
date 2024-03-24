using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleReposicion.Commands.Update
{
    public class UpdateDetalleReposicionCommandHandler : IRequestHandler<UpdateDetalleReposicionCommand, Unit>
    {
        private readonly IDetalleReposicionRepository _repos;
        private readonly IMapper _mapper;

        public UpdateDetalleReposicionCommandHandler(IDetalleReposicionRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDetalleReposicionCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateDetalleReposicionCommand, DetalleReposicionEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<DetalleReposicionEntity>(request);

            await _repos.ActualizarDetalleReposicion(Entity);

            return Unit.Value;
        }
    }
}

