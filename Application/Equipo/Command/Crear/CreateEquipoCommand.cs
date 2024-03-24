using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Equipo.Commands.Crear
{
    public class CreateEquipoCommand : IRequest<int>
    {
        public string CodigoPatrimonial { get; set; }

        public string Nombre { get; set; }
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string NumSerie { get; set; }

        public char Estado { get; set; }
        public string Caracteristicas { get; set; }
        public bool Vigente { get; set; }
        public int CodigoAmbiente { get; set; }
    }
}

