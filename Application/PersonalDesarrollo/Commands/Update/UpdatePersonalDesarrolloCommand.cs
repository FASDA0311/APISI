using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalDesarrollo.Commands.Update
{
    public class UpdatePersonalDesarrolloCommand : IRequest<Unit>
    {
        public int Codigo { get; set; }
        public int CodigoPersonalSoporte { get; set; }
        public int CodigoDesarrollo { get; set; }
    }
}

