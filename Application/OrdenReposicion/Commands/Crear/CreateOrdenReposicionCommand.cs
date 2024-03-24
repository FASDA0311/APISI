using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrdenReposicion.Commands.Crear
{
    public class CreateOrdenReposicionCommand : IRequest<int>
    {
        public DateTime Fecha { get; set; }
        public string Total { get; set; }
        public int CodigoPersonalSoporte { get; set; }
    }
}

