using Application.Desarrollo.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Desarrollo.Queries.Obtener
{
    public class ObtenerDesarrolloQuery : IRequest<DesarrolloDTO>
    {
        public int Id { get; set; }
    }
}
