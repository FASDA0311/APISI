using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Material.Commands.Crear
{
    public class CreateMaterialCommand : IRequest<int>
    {
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public int TipoProductoCodigo { get; set; }
    }
}

