using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IAmbienteRepository
    {
        Task<IEnumerable<AmbienteEntity>> ListarAmbiente();
        Task<AmbienteEntity> ObtenerAmbiente(int id);
        Task<int> CrearAmbiente(AmbienteEntity variable);
        Task ActualizarAmbiente(AmbienteEntity variable);
    }
}

