using Application.Material.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Material.Queries.Obtener
{
    public class ObtenerMaterialQuery : IRequest<MaterialDTO>
    {
        public int Id { get; set; }
    }
}

