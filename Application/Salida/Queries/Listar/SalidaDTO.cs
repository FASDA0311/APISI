using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;


namespace Application.Salida.Queries.Listar
{
    public class SalidaDTO : IMapFrom<SalidaEntity>
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public bool Vigente { get; set; }
        public int CodigoDesarrollo { get; set; }
        public int CodigoPersonalSoporte { get; set; }
        public int CodigoResponsable { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SalidaEntity, SalidaDTO>();
        }
    }
}

