using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActividadDetalleEntrada.Commands.Crear
{
    public class CreateActividadDetalleEntradaCommand : IRequest<int>
    {
        public int CodigoDetalleEntrada { get; set; }

        public int CodigoActividad { get; set; }

    }
}

