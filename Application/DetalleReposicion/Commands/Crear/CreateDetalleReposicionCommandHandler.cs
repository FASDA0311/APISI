using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleReposicion.Commands.Crear
{
    public class CreateDetalleReposicionCommandHandler : IRequestHandler<CreateDetalleReposicionCommand, int>
    {
        private readonly IDetalleReposicionRepository _repository;
        private readonly IMapper _mapper;

        public CreateDetalleReposicionCommandHandler(IDetalleReposicionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDetalleReposicionCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateDetalleReposicionCommand, DetalleReposicionEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<DetalleReposicionEntity>(request);

            var datoComunId = await _repository.CrearDetalleReposicion(Entity);

            return datoComunId;
        }
    }
}


