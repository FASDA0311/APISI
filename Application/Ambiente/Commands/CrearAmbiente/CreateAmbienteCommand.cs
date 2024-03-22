using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ambiente.Commands.CrearAmbiente
{
    public class CreateAmbienteCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
      
    }
}
