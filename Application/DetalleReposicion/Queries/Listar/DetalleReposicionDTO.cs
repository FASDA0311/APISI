using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;


namespace Application.DetalleReposicion.Queries.Listar
{
    public class DetalleReposicionDTO : IMapFrom<DetalleReposicionEntity>
    {
        public int Codigo { get; set; }
        public string Cantidad { get; set; }
        public string PrecioUnitario { get; set; }
        public int CodigoReposicion { get; set; }
        public int CodigoMaterial { get; set; }
        public bool Vigente { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DetalleReposicionEntity, DetalleReposicionDTO>();
        }
    }
}


