using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IActividadDetalleEntradaRepository
    {
        Task<IEnumerable<ActividadDetalleEntradaEntity>> ListarActividadDetalleEntrada();
        Task<ActividadDetalleEntradaEntity> ObtenerActividadDetalleEntrada(int id);
        Task<int> CrearActividadDetalleEntrada(ActividadDetalleEntradaEntity variable);
        Task ActualizarActividadDetalleEntrada(ActividadDetalleEntradaEntity variable);
    }
}
