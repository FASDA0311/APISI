using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documento.Commands.Crear
{
    public class CreateDocumentoCommandHandler : IRequestHandler<CreateDocumentoCommand, int>
    {
        private readonly IDocumentoRepository _repository;
        private readonly IMapper _mapper;

        public CreateDocumentoCommandHandler(IDocumentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDocumentoCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<CreateDocumentoCommand, DocumentoEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<DocumentoEntity>(request);

            var datoComunId = await _repository.CrearDocumento(Entity);

            return datoComunId;
        }
    }
}

