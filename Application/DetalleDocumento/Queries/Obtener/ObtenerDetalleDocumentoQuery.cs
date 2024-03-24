using Application.DetalleDocumento.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleDocumento.Queries.Obtener
{
    public class ObtenerDetalleDocumentoQuery : IRequest<DetalleDocumentoDTO>
    {
        public int Id { get; set; }
    }
}

