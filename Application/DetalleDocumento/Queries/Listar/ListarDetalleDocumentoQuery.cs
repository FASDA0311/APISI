using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleDocumento.Queries.Listar
{
    public class ListarDetalleDocumentoQuery : IRequest<IEnumerable<DetalleDocumentoDTO>>
    {
    }
}
