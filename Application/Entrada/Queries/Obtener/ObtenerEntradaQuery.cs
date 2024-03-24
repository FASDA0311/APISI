using Application.Entrada.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entrada.Queries.Obtener
{
    public class ObtenerEntradaQuery : IRequest<EntradaDTO>
    {
        public int Id { get; set; }
    }
}

