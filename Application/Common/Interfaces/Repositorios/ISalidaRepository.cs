using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface ISalidaRepository
    {
        Task<IEnumerable<SalidaEntity>> ListarSalida();
        Task<SalidaEntity> ObtenerSalida(int id);
        Task<int> CrearSalida(SalidaEntity variable);
        Task ActualizarSalida(SalidaEntity variable);
    }
}

