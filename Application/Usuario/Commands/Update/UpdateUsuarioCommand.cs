using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuario.Commands.Update
{
    public class UpdateUsuarioCommand : IRequest<Unit>
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public string Contraseña { get; set; }

        public char TipoUsuario { get; set; }

        public bool Vigente { get; set; }

        public int CodigoPersonalSoporte { get; set; }
    }
}

