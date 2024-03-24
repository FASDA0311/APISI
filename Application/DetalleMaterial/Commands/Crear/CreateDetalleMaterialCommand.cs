using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleMaterial.Commands.Crear
{
    public class CreateDetalleMaterialCommand : IRequest<int>
    {
        public int CodigoMaterial { get; set; }
        public int CodigoActividad { get; set; }
    }
}

