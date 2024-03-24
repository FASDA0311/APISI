using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;


namespace Application.DetalleEntrada.Queries.Listar
{
    public class DetalleEntradaDTO : IMapFrom<DetalleEntradaEntity>
    {
        public int Codigo { get; set; }
        public string Observacion { get; set; }
        public bool Vigente { get; set; }
        public int CodigoEquipo { get; set; }
        public int CodigoEntrada { get; set; }
        public int CodigoSalida { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DetalleEntradaEntity, DetalleEntradaDTO>();
        }
    }
}

