using Application.DetalleEntrada.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleEntrada.Queries.Obtener
{
    public class ObtenerDetalleEntradaQuery : IRequest<DetalleEntradaDTO>
    {
        public int Id { get; set; }
    }
}

