using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;


namespace Application.TipoMaterial.Queries.Listar
{
    public class TipoMaterialDTO : IMapFrom<TipoMaterialEntity>
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Vigente { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TipoMaterialEntity, TipoMaterialDTO>();
        }
    }
}

