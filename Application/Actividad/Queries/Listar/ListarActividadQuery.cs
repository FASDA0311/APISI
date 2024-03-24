using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actividad.Queries.Listar
{
    public class ListarActividadQuery : IRequest<IEnumerable<ActividadDTO>>
    {
    }
}
