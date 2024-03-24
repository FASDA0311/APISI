using Application.Actividad.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Desarrollo.Queries.Listar
{
    public class ListarDesarrolloQuery : IRequest<IEnumerable<DesarrolloDTO>>
    {
    }
}

