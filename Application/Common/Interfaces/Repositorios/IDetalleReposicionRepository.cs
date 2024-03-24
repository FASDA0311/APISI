using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IDetalleReposicionRepository
    {
        Task<IEnumerable<DetalleReposicionEntity>> ListarDetalleReposicion();
        Task<DetalleReposicionEntity> ObtenerDetalleReposicion(int id);
        Task<int> CrearDetalleReposicion(DetalleReposicionEntity variable);
        Task ActualizarDetalleReposicion(DetalleReposicionEntity variable);
    }
}

