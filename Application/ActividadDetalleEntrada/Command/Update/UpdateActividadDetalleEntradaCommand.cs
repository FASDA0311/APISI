using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActividadDetalleEntrada.Commands.Update
{
    public class UpdateActividadDetalleEntradaCommand : IRequest<Unit>
    {
        public int Codigo { get; set; }
        public int CodigoDetalleEntrada { get; set; }
        public int CodigoActividad { get; set; }
    }
}

