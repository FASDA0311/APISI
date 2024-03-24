using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entrada.Commands.Crear
{
    public class CreateEntradaCommandHandler : IRequestHandler<CreateEntradaCommand, int>
    {
        private readonly IEntradaRepository _repository;
        private readonly IMapper _mapper;

        public CreateEntradaCommandHandler(IEntradaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEntradaCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateEntradaCommand, EntradaEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<EntradaEntity>(request);

            var datoComunId = await _repository.CrearEntrada(Entity);

            return datoComunId;
        }
    }
}

