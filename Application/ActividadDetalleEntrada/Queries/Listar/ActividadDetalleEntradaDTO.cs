using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;


namespace Application.ActividadDetalleEntrada.Queries.Listar 
{
    public class ActividadDetalleEntradaDTO : IMapFrom<ActividadDetalleEntradaEntity>
{
    public int Codigo { get; set; }
    public int CodigoDetalleEntrada { get; set; }

    public int CodigoActividad { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ActividadDetalleEntradaEntity, ActividadDetalleEntradaDTO>();
    }
}
}

