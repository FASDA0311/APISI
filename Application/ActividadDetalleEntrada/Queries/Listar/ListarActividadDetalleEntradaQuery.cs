using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActividadDetalleEntrada.Queries.Listar
{
    public class ListarActividadDetalleEntradaQuery : IRequest<IEnumerable<ActividadDetalleEntradaDTO>>
    {
    }
}

