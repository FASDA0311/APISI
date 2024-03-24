using Application.Responsable.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responsable.Queries.Obtener
{
    public class ObtenerResponsableQuery : IRequest<ResponsableDTO>
    {
        public int Id { get; set; }
    }
}

