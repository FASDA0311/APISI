using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documento.Queries.Listar
{
    public class ListarDocumentoQuery : IRequest<IEnumerable<DocumentoDTO>>
    {
    }
}
