using Application.ActividadDetalleEntrada.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActividadDetalleEntrada.Queries.Obtener
{
    public class ObtenerActividadDetalleEntradaQuery : IRequest<ActividadDetalleEntradaDTO>
    {
        public int Id { get; set; }
    }
}

