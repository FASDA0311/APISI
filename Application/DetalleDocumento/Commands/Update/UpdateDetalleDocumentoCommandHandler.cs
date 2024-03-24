using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleDocumento.Commands.Update
{
    public class UpdateDetalleDocumentoCommandHandler : IRequestHandler<UpdateDetalleDocumentoCommand, Unit>
    {
        private readonly IDetalleDocumentoRepository _repos;
        private readonly IMapper _mapper;

        public UpdateDetalleDocumentoCommandHandler(IDetalleDocumentoRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDetalleDocumentoCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateDetalleDocumentoCommand, DetalleDocumentoEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<DetalleDocumentoEntity>(request);

            await _repos.ActualizarDetalleDocumento(Entity);

            return Unit.Value;
        }
    }
}

