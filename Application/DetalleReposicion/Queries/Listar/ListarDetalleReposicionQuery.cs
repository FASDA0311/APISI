using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleReposicion.Queries.Listar
{
    public class ListarDetalleReposicionQuery : IRequest<IEnumerable<DetalleReposicionDTO>>
    {
    }
}
