using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Equipo.Commands.Crear
{
    public class CreateEquipoCommandHandler : IRequestHandler<CreateEquipoCommand, int>
    {
        private readonly IEquipoRepository _repository;
        private readonly IMapper _mapper;

        public CreateEquipoCommandHandler(IEquipoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEquipoCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateEquipoCommand, EquipoEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<EquipoEntity>(request);

            var datoComunId = await _repository.CrearEquipo(Entity);

            return datoComunId;
        }
    }
}

