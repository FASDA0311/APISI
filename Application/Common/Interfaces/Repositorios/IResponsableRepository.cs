using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IResponsableRepository
    {
        Task<IEnumerable<ResponsableEntity>> ListarResponsable();
        Task<ResponsableEntity> ObtenerResponsable(int id);
        Task<int> CrearResponsable(ResponsableEntity variable);
        Task ActualizarResponsable(ResponsableEntity variable);
    }
}
