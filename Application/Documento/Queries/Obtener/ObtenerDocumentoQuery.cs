using Application.Documento.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documento.Queries.Obtener
{
    public class ObtenerDocumentoQuery : IRequest<DocumentoDTO>
    {
        public int Id { get; set; }
    }
}

