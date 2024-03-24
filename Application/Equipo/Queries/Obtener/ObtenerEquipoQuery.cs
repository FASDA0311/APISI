using Application.Equipo.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Equipo.Queries.Obtener
{
    public class ObtenerEquipoQuery : IRequest<EquipoDTO>
    {
        public int Id { get; set; }
    }
}

