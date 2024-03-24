using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrdenReposicion.Queries.Listar
{
    public class ListarOrdenReposicionQuery : IRequest<IEnumerable<OrdenReposicionDTO>>
    {
    }
}

