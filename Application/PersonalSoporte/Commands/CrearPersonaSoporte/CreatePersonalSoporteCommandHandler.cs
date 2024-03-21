using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalSoporte.Commands.CrearPersonaSoporte
{
    public class CreatePersonalSoporteCommandHandler : IRequestHandler<CreatePersonalSoporteCommand , int>
    {
        private readonly IPersonalSoporteRepository _repository;
        private readonly IMapper _mapper;

        public CreatePersonalSoporteCommandHandler(IPersonalSoporteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePersonalSoporteCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreatePersonalSoporteCommand, PersonalSoporteEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<PersonalSoporteEntity>(request);

            var datoComunId = await _repository.CrearPersonalSoporte(Entity);

            return datoComunId;
        }
    }
}
