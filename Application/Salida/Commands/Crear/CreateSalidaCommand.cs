using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Salida.Commands.Crear
{
    public class CreateSalidaCommand : IRequest<int>
    {
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public int CodigoDesarrollo { get; set; }
        public int CodigoPersonalSoporte { get; set; }
        public int CodigoResponsable { get; set; }
    }
}

