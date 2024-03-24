using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;


namespace Application.PersonalDesarrollo.Queries.Listar
{
    public class PersonalDesarrolloDTO : IMapFrom<PersonalDesarrolloEntity>
    {
        public int Codigo { get; set; }
        public int CodigoPersonalSoporte { get; set; }
        public int CodigoDesarrollo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonalDesarrolloEntity, PersonalDesarrolloDTO>();
        }
    }
}
