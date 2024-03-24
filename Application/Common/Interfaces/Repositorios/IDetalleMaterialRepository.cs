using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IDetalleMaterialRepository
    {
        Task<IEnumerable<DetalleMaterialEntity>> ListarDetalleMaterial();
        Task<DetalleMaterialEntity> ObtenerDetalleMaterial(int id);
        Task<int> CrearDetalleMaterial(DetalleMaterialEntity variable);
        Task ActualizarDetalleMaterial(DetalleMaterialEntity variable);
    }
}

