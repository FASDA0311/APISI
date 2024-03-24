using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleDocumento.Commands.Crear
{
    public class CreateDetalleDocumentoCommandHandler : IRequestHandler<CreateDetalleDocumentoCommand, int>
    {
        private readonly IDetalleDocumentoRepository _repository;
        private readonly IMapper _mapper;

        public CreateDetalleDocumentoCommandHandler(IDetalleDocumentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDetalleDocumentoCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateDetalleDocumentoCommand, DetalleDocumentoEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<DetalleDocumentoEntity>(request);

            var datoComunId = await _repository.CrearDetalleDocumento(Entity);

            return datoComunId;
        }
    }
}

