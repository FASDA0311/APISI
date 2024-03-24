using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;


namespace Application.OrdenReposicion.Queries.Listar
{
    public class OrdenReposicionDTO : IMapFrom<OrdenReposicionEntity>
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string Total { get; set; }
        public int CodigoPersonalSoporte { get; set; }
        public bool Vigente { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrdenReposicionEntity, OrdenReposicionDTO>();
        }
    }
}

