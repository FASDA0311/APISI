using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActividadDetalleEntrada.Commands.Crear
{
    public class CreateActividadDetalleEntradaCommandHandler : IRequestHandler<CreateActividadDetalleEntradaCommand, int>
    {
        private readonly IActividadDetalleEntradaRepository _repository;
        private readonly IMapper _mapper;

        public CreateActividadDetalleEntradaCommandHandler(IActividadDetalleEntradaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateActividadDetalleEntradaCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateActividadDetalleEntradaCommand, ActividadDetalleEntradaEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<ActividadDetalleEntradaEntity>(request);

            var datoComunId = await _repository.CrearActividadDetalleEntrada(Entity);

            return datoComunId;
        }
    }
}

