using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class SalidaEntity
    {
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public bool Vigente { get; set; }
        public int CodigoDesarrollo { get; set; }
        public int CodigoPersonalSoporte { get; set; }
        public int CodigoResponsable { get; set; }
    }
}
