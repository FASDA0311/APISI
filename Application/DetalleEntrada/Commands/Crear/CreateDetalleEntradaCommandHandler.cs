using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleEntrada.Commands.Crear
{
    public class CreateDetalleEntradaCommandHandler : IRequestHandler<CreateDetalleEntradaCommand, int>
    {
        private readonly IDetalleEntradaRepository _repository;
        private readonly IMapper _mapper;

        public CreateDetalleEntradaCommandHandler(IDetalleEntradaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDetalleEntradaCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateDetalleEntradaCommand, DetalleEntradaEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<DetalleEntradaEntity>(request);

            var datoComunId = await _repository.CrearDetalleEntrada(Entity);

            return datoComunId;
        }
    }
}

