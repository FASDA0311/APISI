using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PersonalSoporte.Queries.ObtenerPersonaSoporte
{
    public class ObtenerPersonalSoporteQuery : IRequest<PersonalSoporteDTO>
    {
        public int Id { get; set; }
    }
}
