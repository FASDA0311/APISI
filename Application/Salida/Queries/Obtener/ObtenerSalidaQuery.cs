using Application.Salida.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Salida.Queries.Obtener
{
    public class ObtenerSalidaQuery : IRequest<SalidaDTO>
    {
        public int Id { get; set; }
    }
}

