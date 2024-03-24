using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entrada.Commands.Update
{
    public class UpdateEntradaCommandHandler : IRequestHandler<UpdateEntradaCommand, Unit>
    {
        private readonly IEntradaRepository _repos;
        private readonly IMapper _mapper;

        public UpdateEntradaCommandHandler(IEntradaRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEntradaCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateEntradaCommand, EntradaEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<EntradaEntity>(request);

            await _repos.ActualizarEntrada(Entity);

            return Unit.Value;
        }
    }
}


