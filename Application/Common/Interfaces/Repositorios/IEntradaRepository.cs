using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IEntradaRepository
    {
        Task<IEnumerable<EntradaEntity>> ListarEntrada();
        Task<EntradaEntity> ObtenerEntrada(int id);
        Task<int> CrearEntrada(EntradaEntity variable);
        Task ActualizarEntrada(EntradaEntity variable);
    }
}
