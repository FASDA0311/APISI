using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuario.Commands.Crear
{
    public class CreateUsuarioCommand : IRequest<int>
    {
        public string Nombre { get; set; }

        public string Contraseña { get; set; }

        public char TipoUsuario { get; set; }

        public bool Vigente { get; set; }

        public int CodigoPersonalSoporte { get; set; }
    }
}

