using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Desarrollo.Commands.Update
{
    public class UpdateDesarrolloCommand : IRequest<Unit>
    {
        public int Codigo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Detalle { get; set; }
        public char Estado { get; set; }
        public bool Vigente { get; set; }
        public int CodigoEntrada { get; set; }
    }
}

