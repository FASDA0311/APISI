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
        Task<PersonalSoporteEntity> ObtenerPersonalSoporte(int id);
        Task<int> CrearPersonalSoporte(PersonalSoporteEntity variable);
        Task ActualizarPersonalSoporte(PersonalSoporteEntity variable);
    }
}
