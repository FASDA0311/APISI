using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleEntrada.Queries.Listar
{
    public class ListarDetalleEntradaQuery : IRequest<IEnumerable<DetalleEntradaDTO>>
    {
    }
}

