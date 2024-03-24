using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TipoMaterial.Commands.Crear
{
    public class CreateTipoMaterialCommand : IRequest<int>
    {
        public string Nombre { get; set; }
    }
}

