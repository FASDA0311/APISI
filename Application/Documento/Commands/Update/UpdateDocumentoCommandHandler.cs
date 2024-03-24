using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documento.Commands.Update
{
    public class UpdateDocumentoCommandHandler : IRequestHandler<UpdateDocumentoCommand, Unit>
    {
        private readonly IDocumentoRepository _repos;
        private readonly IMapper _mapper;

        public UpdateDocumentoCommandHandler(IDocumentoRepository repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDocumentoCommand request, CancellationToken cancellationToken)
        {
            var mapperconfig = new MapperConfiguration(c =>
            {
                c.CreateMap<UpdateDocumentoCommand, DocumentoEntity>();
            });
            var _mapperconfig = mapperconfig.CreateMapper();
            var Entity = _mapperconfig.Map<DocumentoEntity>(request);

            await _repos.ActualizarDocumento(Entity);

            return Unit.Value;
        }
    }
}
