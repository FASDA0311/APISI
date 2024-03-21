using Application.Equipo.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responsable.Queries.Listar
{
    public class ListarResponsableQuery : IRequest<IEnumerable<ResponsableDTO>>
    {
    }
}
