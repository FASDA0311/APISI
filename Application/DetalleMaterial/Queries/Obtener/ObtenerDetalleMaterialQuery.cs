using Application.DetalleMaterial.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleMaterial.Queries.Obtener
{
    public class ObtenerDetalleMaterialQuery : IRequest<DetalleMaterialDTO>
    {
        public int Id { get; set; }
    }
}

