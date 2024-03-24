using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actividad.Commands.Update
{
    public class UpdateActividadCommand : IRequest<Unit>
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public char Estado { get; set; }
        public int CodigoDesarrollo { get; set; }
    }
}

