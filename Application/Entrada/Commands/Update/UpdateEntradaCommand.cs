using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entrada.Commands.Update
{
    public class UpdateEntradaCommand : IRequest<Unit>
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public char NivelPrioridad { get; set; }
        public char Estado { get; set; }
        public bool Vigente { get; set; }
        public int CodigoPersonalSoporte { get; set; }
        public int CodigoDocumento { get; set; }
        public int CodigoResponsable { get; set; }
    }
}


