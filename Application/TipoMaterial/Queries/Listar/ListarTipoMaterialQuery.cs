using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TipoMaterial.Queries.Listar
{
    public class ListarTipoMaterialQuery : IRequest<IEnumerable<TipoMaterialDTO>>
    {
    }
}

