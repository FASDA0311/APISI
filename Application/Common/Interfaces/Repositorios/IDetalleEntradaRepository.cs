using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IDetalleEntradaRepository
    {
        Task<IEnumerable<DetalleEntradaEntity>> ListarDetalleEntrada();
        Task<DetalleEntradaEntity> ObtenerDetalleEntrada(int id);
        Task<int> CrearDetalleEntrada(DetalleEntradaEntity variable);
        Task ActualizarDetalleEntrada(DetalleEntradaEntity variable);
    }
}

