using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalDesarrollo.Commands.Crear
{
    public class CreatePersonalDesarrolloCommand : IRequest<int>
    {
        public int CodigoPersonalSoporte { get; set; }
        public int CodigoDesarrollo { get; set; }
    }
}

