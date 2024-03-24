using Application.PersonalDesarrollo.Queries.Listar;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalDesarrollo.Queries.Obtener
{
    public class ObtenerPersonalDesarrolloQuery : IRequest<PersonalDesarrolloDTO>
    {
        public int Id { get; set; }
    }
}

