using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;


namespace Application.DetalleMaterial.Queries.Listar
{
    public class DetalleMaterialDTO : IMapFrom<DetalleMaterialEntity>
    {
        public int Codigo { get; set; }
        public int CodigoMaterial { get; set; }
        public int CodigoActividad { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DetalleMaterialEntity, DetalleMaterialDTO>();
        }
    }
}

