using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleDocumento.Commands.Update
{
    public class UpdateDetalleDocumentoCommand : IRequest<Unit>
    {
        public int Codigo { get; set; }

        public int CodigoEquipo { get; set; }

        public int CodigoDocumento { get; set; }
    }
}

