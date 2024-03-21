using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalSoporte.Commands.CrearPersonaSoporte
{
    public class CreatePersonalSoporteCommand : IRequest<int>
    {
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string DNI { get; set; }
    }
}
