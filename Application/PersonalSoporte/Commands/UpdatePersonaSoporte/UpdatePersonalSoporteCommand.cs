using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalSoporte.Commands.UpdatePersonaSoporte
{
    public class UpdatePersonalSoporteCommand : IRequest<Unit>
    {
        public int Codigo { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string DNI { get; set; }
        public bool Estado { get; set; }
        public int CodigoUsuario { get; set; }
    }
}
