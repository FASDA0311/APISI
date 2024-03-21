using Application.Common.Mappings;
using AutoMapper;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuario.Queries.Listar
{
    public class UsuarioDTO : IMapFrom<UsuarioEntity>
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public string Contraseña { get; set; }

        public char TipoUsuario { get; set; }

        public bool Vigente { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<UsuarioEntity, UsuarioDTO>();
        }
    }
}
