using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IOrdenReposicionRepository
    {
        Task<IEnumerable<OrdenReposicionEntity>> ListarOrdenReposicion();
        Task<OrdenReposicionEntity> ObtenerOrdenReposicion(int id);
        Task<int> CrearOrdenReposicion(OrdenReposicionEntity variable);
        Task ActualizarOrdenReposicion(OrdenReposicionEntity variable);
    }
}

