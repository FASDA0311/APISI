using Application.Usuario.Queries.Listar;
using Application.Common.Interfaces.Repositorios;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuario.Queries.Obtener
{
    public class ObtenerUsuarioQueryHandler : IRequestHandler<ObtenerUsuarioQuery, UsuarioDTO>
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly IMapper _mapper;

        public ObtenerUsuarioQueryHandler(IUsuarioRepository UsuarioRepository, IMapper mapper)
        {
            _UsuarioRepository = UsuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Handle(ObtenerUsuarioQuery request, CancellationToken cancellationToken)
        {
            var variable = await _UsuarioRepository.ObtenerUsuario(request.Id);
            return _mapper.Map<UsuarioDTO>(variable);
        }
    }
}

