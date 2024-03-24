using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;


namespace Application.Actividad.Queries.Listar
{
    public class ActividadDTO : IMapFrom<ActividadEntity>
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public char Estado { get; set; }
        public int CodigoDesarrollo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ActividadEntity, ActividadDTO>();
        }
    }
}

