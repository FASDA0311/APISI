using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Salida.Commands.Crear
{
    public class CreateSalidaCommandHandler : IRequestHandler<CreateSalidaCommand, int>
    {
        private readonly ISalidaRepository _repository;
        private readonly IMapper _mapper;

        public CreateSalidaCommandHandler(ISalidaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateSalidaCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateSalidaCommand, SalidaEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<SalidaEntity>(request);

            var datoComunId = await _repository.CrearSalida(Entity);

            return datoComunId;
        }
    }
}

