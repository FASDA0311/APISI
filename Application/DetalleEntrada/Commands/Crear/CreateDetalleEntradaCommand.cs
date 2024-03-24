using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleEntrada.Commands.Crear
{
    public class CreateDetalleEntradaCommand : IRequest<int>
    {
        public string Observacion { get; set; }
        public int CodigoEquipo { get; set; }
        public int CodigoEntrada { get; set; }
        public int CodigoSalida { get; set; }
    }
}
