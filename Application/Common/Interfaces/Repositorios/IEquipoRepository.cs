using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IEquipoRepository
    {
        Task<IEnumerable<EquipoEntity>> ListarEquipo();
        Task<EquipoEntity> ObtenerEquipo(int id);
        Task<int> CrearEquipo(EquipoEntity variable);
        Task ActualizarEquipo(EquipoEntity variable);
    }
}

