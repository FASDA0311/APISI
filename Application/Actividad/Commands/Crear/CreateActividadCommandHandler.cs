using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actividad.Commands.Crear
{
    public class CreateActividadCommandHandler : IRequestHandler<CreateActividadCommand, int>
    {
        private readonly IActividadRepository _repository;
        private readonly IMapper _mapper;

        public CreateActividadCommandHandler(IActividadRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateActividadCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateActividadCommand, ActividadEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<ActividadEntity>(request);

            var datoComunId = await _repository.CrearActividad(Entity);

            return datoComunId;
        }
    }
}

