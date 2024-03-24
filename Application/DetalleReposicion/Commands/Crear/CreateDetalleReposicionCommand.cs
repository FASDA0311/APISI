using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleReposicion.Commands.Crear
{
    public class CreateDetalleReposicionCommand : IRequest<int>
    {
        public string Cantidad { get; set; }
        public string PrecioUnitario { get; set; }
        public int CodigoReposicion { get; set; }
        public int CodigoMaterial { get; set; }
    }
}

