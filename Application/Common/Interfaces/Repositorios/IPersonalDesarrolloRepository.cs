using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IPersonalDesarrolloRepository
    {
        Task<IEnumerable<PersonalDesarrolloEntity>> ListarPersonalDesarrollo();
        Task<PersonalDesarrolloEntity> ObtenerPersonalDesarrollo(int id);
        Task<int> CrearPersonalDesarrollo(PersonalDesarrolloEntity variable);
        Task ActualizarPersonalDesarrollo(PersonalDesarrolloEntity variable);
    }
}

