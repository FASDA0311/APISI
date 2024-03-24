using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IMaterialRepository
    {
        Task<IEnumerable<MaterialEntity>> ListarMaterial();
        Task<MaterialEntity> ObtenerMaterial(int id);
        Task<int> CrearMaterial(MaterialEntity variable);
        Task ActualizarMaterial(MaterialEntity variable);
    }
}

