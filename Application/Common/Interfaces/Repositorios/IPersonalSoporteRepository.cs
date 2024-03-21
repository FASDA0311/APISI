using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IPersonalSoporteRepository
    {
        Task<IEnumerable<PersonalSoporteEntity>> ListarPersonalSoporte();
    }
}
