using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalDesarrollo.Commands.Crear
{
    public class CreatePersonalDesarrolloCommandHandler : IRequestHandler<CreatePersonalDesarrolloCommand, int>
    {
        private readonly IPersonalDesarrolloRepository _repository;
        private readonly IMapper _mapper;

        public CreatePersonalDesarrolloCommandHandler(IPersonalDesarrolloRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePersonalDesarrolloCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreatePersonalDesarrolloCommand, PersonalDesarrolloEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<PersonalDesarrolloEntity>(request);

            var datoComunId = await _repository.CrearPersonalDesarrollo(Entity);

            return datoComunId;
        }
    }
}

