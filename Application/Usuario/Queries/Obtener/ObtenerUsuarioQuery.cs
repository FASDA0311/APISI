using Application.Usuario.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuario.Queries.Obtener
{
    public class ObtenerUsuarioQuery : IRequest<UsuarioDTO>
    {
        public int Id { get; set; }
    }
}
