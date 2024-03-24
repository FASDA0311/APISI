using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrdenReposicion.Commands.Crear
{
    public class CreateOrdenReposicionCommandHandler : IRequestHandler<CreateOrdenReposicionCommand, int>
    {
        private readonly IOrdenReposicionRepository _repository;
        private readonly IMapper _mapper;

        public CreateOrdenReposicionCommandHandler(IOrdenReposicionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOrdenReposicionCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateOrdenReposicionCommand, OrdenReposicionEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<OrdenReposicionEntity>(request);

            var datoComunId = await _repository.CrearOrdenReposicion(Entity);

            return datoComunId;
        }
    }
}

