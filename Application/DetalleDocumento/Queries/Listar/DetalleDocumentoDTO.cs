using Application.Common.Mappings;
using AutoMapper;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DetalleDocumento.Queries.Listar
{
    public class DetalleDocumentoDTO : IMapFrom<DetalleDocumentoEntity>
    {
            public int Codigo { get; set; }

            public int CodigoEquipo { get; set; }

            public int CodigoDocumento { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<DetalleDocumentoEntity, DetalleDocumentoDTO>();
        }
    }
}
