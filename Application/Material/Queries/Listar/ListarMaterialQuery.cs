using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Material.Queries.Listar
{
    public class ListarMaterialQuery : IRequest<IEnumerable<MaterialDTO>>
    {
    }
}

