using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleMaterial.Queries.Listar
{
    public class ListarDetalleMaterialQuery : IRequest<IEnumerable<DetalleMaterialDTO>>
    {
    }
}

