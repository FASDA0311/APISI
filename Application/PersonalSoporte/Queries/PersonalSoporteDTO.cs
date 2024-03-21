using Application.Common.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;


namespace Application.PersonalSoporte.Queries
{
    public class PersonalSoporteDTO : IMapFrom<PersonalSoporteEntity>
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public int CodigoUsuario { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonalSoporteEntity, PersonalSoporteDTO>();
        }
    }
}
