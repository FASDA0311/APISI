using Application.OrdenReposicion.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrdenReposicion.Queries.Obtener
{
    public class ObtenerOrdenReposicionQuery : IRequest<OrdenReposicionDTO>
    {
        public int Id { get; set; }
    }
}

