using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IDesarrolloRepository
    {
        Task<IEnumerable<DesarrolloEntity>> ListarDesarrollo();
        Task<DesarrolloEntity> ObtenerDesarrollo(int id);
        Task<int> CrearDesarrollo(DesarrolloEntity variable);
        Task ActualizarDesarrollo(DesarrolloEntity variable);
    }
}

