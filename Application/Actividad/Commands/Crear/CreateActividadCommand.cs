using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actividad.Commands.Crear
{
    public class CreateActividadCommand : IRequest<int>
    {
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public char Estado { get; set; }
        public int CodigoDesarrollo { get; set; }
    }
}

