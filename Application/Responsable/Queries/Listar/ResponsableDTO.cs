using Application.Common.Mappings;
using Application.Equipo.Queries.Listar;
using AutoMapper;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responsable.Queries.Listar
{
    public class ResponsableDTO : IMapFrom<ResponsableEntity>
    {
        public int Codigo { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string DNI { get; set; }
        public bool Vigente { get; set; }
        public int CodigoAmbiente { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EquipoEntity, EquipoDTO>();
        }
    }
}
