using Application.Actividad.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actividad.Queries.Obtener
{
    public class ObtenerActividadQuery : IRequest<ActividadDTO>
    {
        public int Id { get; set; }
    }
}

