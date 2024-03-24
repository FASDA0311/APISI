using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleMaterial.Commands.Update
{
    public class UpdateDetalleMaterialCommand : IRequest<Unit>
    {
        public int Codigo { get; set; }
        public int CodigoMaterial { get; set; }
        public int CodigoActividad { get; set; }
    }
}


