using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalSoporte.Commands.UpdatePersonaSoporte
{
    public class UpdatePersonalSoporteCommandHandler : IRequestHandler<UpdatePersonalSoporteCommand, Unit>
    {
        private readonly IPersonalSoporteRepository _repos;
        private readonly IMapper _mapper;

        public UpdatePersonalSoporteCommandHandler(IPersonalSoporteRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePersonalSoporteCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdatePersonalSoporteCommand, PersonalSoporteEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<PersonalSoporteEntity>(request);

            await _repos.ActualizarPersonalSoporte(Entity);

            return Unit.Value;
        }
    }
}
