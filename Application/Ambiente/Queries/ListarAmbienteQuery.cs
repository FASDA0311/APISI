using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ambiente.Queries
{
    public class ListarAmbienteQuery : IRequest<IEnumerable<AmbienteDTO>>
    {
    }
}
