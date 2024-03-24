using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ambiente.Queries.Obtener
{
    public class ObtenerAmbienteQuery : IRequest<AmbienteDTO>
    {
        public int Id { get; set; }
    }
}

