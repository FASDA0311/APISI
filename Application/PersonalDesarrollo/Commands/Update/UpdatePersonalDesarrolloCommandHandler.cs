using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalDesarrollo.Commands.Update
{
    public class UpdatePersonalDesarrolloCommandHandler : IRequestHandler<UpdatePersonalDesarrolloCommand, Unit>
    {
        private readonly IPersonalDesarrolloRepository _repos;
        private readonly IMapper _mapper;

        public UpdatePersonalDesarrolloCommandHandler(IPersonalDesarrolloRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePersonalDesarrolloCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdatePersonalDesarrolloCommand, PersonalDesarrolloEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<PersonalDesarrolloEntity>(request);

            await _repos.ActualizarPersonalDesarrollo(Entity);

            return Unit.Value;
        }
    }
}

