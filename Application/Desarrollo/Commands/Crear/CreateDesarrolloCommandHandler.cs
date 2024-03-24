using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Desarrollo.Commands.Crear
{
    public class CreateDesarrolloCommandHandler : IRequestHandler<CreateDesarrolloCommand, int>
    {
        private readonly IDesarrolloRepository _repository;
        private readonly IMapper _mapper;

        public CreateDesarrolloCommandHandler(IDesarrolloRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDesarrolloCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateDesarrolloCommand, DesarrolloEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<DesarrolloEntity>(request);

            var datoComunId = await _repository.CrearDesarrollo(Entity);

            return datoComunId;
        }
    }
}

