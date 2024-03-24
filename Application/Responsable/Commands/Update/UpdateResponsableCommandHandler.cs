using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responsable.Commands.Update
{
    public class UpdateResponsableCommandHandler : IRequestHandler<UpdateResponsableCommand, Unit>
    {
        private readonly IResponsableRepository _repos;
        private readonly IMapper _mapper;

        public UpdateResponsableCommandHandler(IResponsableRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateResponsableCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateResponsableCommand, ResponsableEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<ResponsableEntity>(request);

            await _repos.ActualizarResponsable(Entity);

            return Unit.Value;
        }
    }
}

