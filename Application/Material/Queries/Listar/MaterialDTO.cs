using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;


namespace Application.Material.Queries.Listar
{
    public class MaterialDTO : IMapFrom<MaterialEntity>
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public int TipoProductoCodigo { get; set; }
        public bool Vigente { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MaterialEntity, MaterialDTO>();
        }
    }
}

