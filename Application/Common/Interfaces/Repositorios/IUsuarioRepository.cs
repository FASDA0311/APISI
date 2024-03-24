using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositorios
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioEntity>> ListarUsuario();
        Task<UsuarioEntity> ObtenerUsuario(int id);
        Task<int> CrearUsuario(UsuarioEntity variable);
        Task ActualizarUsuario(UsuarioEntity variable);
    }
}

