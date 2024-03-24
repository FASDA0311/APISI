using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Material.Commands.Update
{
    public class UpdateMaterialCommand : IRequest<Unit>
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public int TipoProductoCodigo { get; set; }
        public bool Vigente { get; set; }
    }
}

