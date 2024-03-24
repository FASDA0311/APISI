using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Desarrollo.Commands.Crear
{
    public class CreateDesarrolloCommand : IRequest<int>
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Detalle { get; set; }
        public char Estado { get; set; }
        public int CodigoEntrada { get; set; }
    }
}

