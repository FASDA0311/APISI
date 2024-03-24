using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;


namespace Application.Desarrollo.Queries.Listar
{
    public class DesarrolloDTO : IMapFrom<DesarrolloEntity>
    {
        public int Codigo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Detalle { get; set; }
        public char Estado { get; set; }
        public bool Vigente { get; set; }
        public int CodigoEntrada { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DesarrolloEntity, DesarrolloDTO>();
        }
    }
}


