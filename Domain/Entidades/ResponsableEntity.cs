using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ResponsableEntity
    {
        public int Codigo { get; set; }
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string DNI { get; set; }
        public bool Vigente { get; set; }
        public int CodigoAmbiente { get; set; }
    }
    
}
