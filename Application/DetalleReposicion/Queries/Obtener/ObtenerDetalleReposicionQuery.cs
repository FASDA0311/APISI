using Application.DetalleReposicion.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleReposicion.Queries.Obtener
{
    public class ObtenerDetalleReposicionQuery : IRequest<DetalleReposicionDTO>
    {
        public int Id { get; set; }
    }
}

