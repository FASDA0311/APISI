using Application.TipoMaterial.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TipoMaterial.Queries.Obtener
{
    public class ObtenerTipoMaterialQuery : IRequest<TipoMaterialDTO>
    {
        public int Id { get; set; }
    }
}

