using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalSoporte.Queries
{
    public class ListarPersonaSoporteQuery : IRequest<IEnumerable<PersonalSoporteDTO>>
    {
    }
}
