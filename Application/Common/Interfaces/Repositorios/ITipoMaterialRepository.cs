using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface ITipoMaterialRepository
    {
        Task<IEnumerable<TipoMaterialEntity>> ListarTipoMaterial();
        Task<TipoMaterialEntity> ObtenerTipoMaterial(int id);
        Task<int> CrearTipoMaterial(TipoMaterialEntity variable);
        Task ActualizarTipoMaterial(TipoMaterialEntity variable);
    }
}

