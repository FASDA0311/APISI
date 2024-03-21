using Application.Common.Mappings;
using Application.PersonalSoporte.Queries;
using AutoMapper;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ambiente.Queries
{
    public class AmbienteDTO: IMapFrom<AmbienteEntity>
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Vigente { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AmbienteEntity, AmbienteDTO>();
        }
    }
}
