using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrdenReposicion.Commands.Update
{
    public class UpdateOrdenReposicionCommandHandler : IRequestHandler<UpdateOrdenReposicionCommand, Unit>
    {
        private readonly IOrdenReposicionRepository _repos;
        private readonly IMapper _mapper;

        public UpdateOrdenReposicionCommandHandler(IOrdenReposicionRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrdenReposicionCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateOrdenReposicionCommand, OrdenReposicionEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<OrdenReposicionEntity>(request);

            await _repos.ActualizarOrdenReposicion(Entity);

            return Unit.Value;
        }
    }
}


