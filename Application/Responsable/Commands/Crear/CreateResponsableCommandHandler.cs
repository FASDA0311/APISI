using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responsable.Commands.Crear
{
    public class CreateResponsableCommandHandler : IRequestHandler<CreateResponsableCommand, int>
    {
        private readonly IResponsableRepository _repository;
        private readonly IMapper _mapper;

        public CreateResponsableCommandHandler(IResponsableRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateResponsableCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateResponsableCommand, ResponsableEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<ResponsableEntity>(request);

            var datoComunId = await _repository.CrearResponsable(Entity);

            return datoComunId;
        }
    }
}


