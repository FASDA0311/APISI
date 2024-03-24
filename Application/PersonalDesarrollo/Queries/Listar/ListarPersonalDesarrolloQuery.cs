using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalDesarrollo.Queries.Listar
{
    public class ListarPersonalDesarrolloQuery : IRequest<IEnumerable<PersonalDesarrolloDTO>>
    {
    }
}

