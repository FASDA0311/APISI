using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleDocumento.Commands.Crear
{
    public class CreateDetalleDocumentoCommand : IRequest<int>
    {

        public int CodigoEquipo { get; set; }

        public int CodigoDocumento { get; set; }
    }
}

