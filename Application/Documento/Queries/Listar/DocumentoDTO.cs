using Application.Common.Mappings;
using AutoMapper;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Documento.Queries.Listar
{
    public class DocumentoDTO : IMapFrom<DocumentoEntity>
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }

        public string Archivo { get; set; }
        public bool Vigente { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DocumentoEntity, DocumentoDTO>();
        }
    }
}
