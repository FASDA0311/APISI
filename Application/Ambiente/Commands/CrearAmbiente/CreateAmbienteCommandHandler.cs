using Application.Common.Interfaces.Repositorios;
using Application.PersonalSoporte.Commands.CrearPersonaSoporte;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ambiente.Commands.CrearAmbiente
{
    public class CreateAmbienteCommandHandler : IRequestHandler<CreateAmbienteCommand, int>
    {
        private readonly IAmbienteRepository _repository;
        private readonly IMapper _mapper;

        public CreateAmbienteCommandHandler(IAmbienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAmbienteCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateAmbienteCommand, AmbienteEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<AmbienteEntity>(request);

            var datoComunId = await _repository.CrearAmbiente(Entity);

            return datoComunId;
        }

       
    }
}
