using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IActividadRepository
    {
        Task<IEnumerable<ActividadEntity>> ListarActividad();
        Task<ActividadEntity> ObtenerActividad(int id);
        Task<int> CrearActividad(ActividadEntity variable);
        Task ActualizarActividad(ActividadEntity variable);
    }
}

